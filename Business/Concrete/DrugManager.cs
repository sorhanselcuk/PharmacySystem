using Business.Abstract;
using Business.Constants;
using Business.Utilities;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Security;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class DrugManager : IDrugService
    {
        private IDrugDal _drugDal;

        public DrugManager(IDrugDal drugDal)
        {
            _drugDal = drugDal;
        }

        [AuthorizationAspect("IDrugService.Add,IDrugService")]
        [ValidationAspect(typeof(DrugValidator))]
        [CacheRemoveAspect("IDrugService.Get")]
        public IResult Add(Drug drug)
        {
            var result = BusinessRules.Run(CheckIfDrugNameExists(drug.Name));
            if (result != null)
                return result;
            _drugDal.Add(drug);
            return new SuccessResult(Message.Success);
        }

        [AuthorizationAspect("IDrugService.Delete,IDrugService")]
        [CacheRemoveAspect("IDrugService.Get")]
        public IResult Delete(Drug drug)
        {
            var result = BusinessRules.Run(CheckIfOwnerDrug(drug));
            if (result != null)
                return result;
            _drugDal.Delete(drug);
            return new SuccessResult(Message.Success);
        }
        [CacheAspect(60)]
        public IDataResult<List<Drug>> GetDrugs()
        {
            var data = _drugDal.GetAll();
            if (data.Count == 0)
            {
                return new ErrorDataResult<List<Drug>>(Message.ThereIsNoSuchData);
            }
            return new SuccessDataResult<List<Drug>>(data, Message.Success);
        }

        [CacheAspect(60)]
        public IDataResult<List<Drug>> GetDrugsBySupplierId(int supplierId)
        {
            var data = _drugDal.GetAll(d => d.SupplierId == supplierId);
            if (data.Count == 0)
            {
                return new ErrorDataResult<List<Drug>>(Message.ThereIsNoSuchData);
            }
            return new SuccessDataResult<List<Drug>>(data, Message.Success);
        }

        [CacheAspect(60)]
        public IDataResult<List<Drug>> GetDrugsWithoutPrescription()
        {
            var data = _drugDal.GetAll(d => d.IsPrescription == true);
            if (data.Count == 0)
            {
                return new ErrorDataResult<List<Drug>>(Message.ThereIsNoSuchData);
            }
            return new SuccessDataResult<List<Drug>>(data, Message.Success);
        }

        [CacheAspect(60)]
        public IDataResult<List<Drug>> GetDrugsWithPrescription()
        {
            var data = _drugDal.GetAll(d => d.IsPrescription == true);
            if (data.Count == 0)
            {
                return new ErrorDataResult<List<Drug>>(Message.ThereIsNoSuchData);
            }
            return new SuccessDataResult<List<Drug>>(data, Message.Success);
        }

        [AuthorizationAspect("IDrugService.Update,IDrugService")]
        [ValidationAspect(typeof(DrugValidator))]
        [CacheRemoveAspect("IDrugService.Get")]
        public IResult Update(Drug drug)
        {
            var result = BusinessRules.Run(CheckIfOwnerDrug(drug));
            if (result != null)
                return result;
            _drugDal.Update(drug);
            return new SuccessResult(Message.Success);
        }
        private IResult CheckIfDrugNameExists(string name)
        {
            var result = _drugDal.Get(d => d.Name == name);
            if (result is null)
                return new SuccessResult();
            return new ErrorResult(Message.SuchDataAlreadyExists);
        }
        private IResult CheckIfOwnerDrug(Drug drug)
        {
            if(drug.SupplierId != UserHelper.GetSupplierId())
            {
                return new ErrorResult(Message.TheDrugIsNotOwnedByYourCompany);
            }
            return new SuccessResult();
        }
    }
}
