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
    public class MedicineManager : IMedicineService
    {
        private IMedicineDal _medicineDal;

        public MedicineManager(IMedicineDal medicineDal)
        {
            _medicineDal = medicineDal;
        }

        [AuthorizationAspect("IMedicineService.Add,IMedicineService")]
        [ValidationAspect(typeof(DrugValidator))]
        [CacheRemoveAspect("IMedicineService.Get")]
        public IResult Add(Medicine medicine)
        {
            var result = BusinessRules.Run(
                CheckIfMedicineNameExists(medicine.Name),
                CheckIfTITCKCodeExists(medicine.TITCKCode));

            if (result != null)
                return result;
            _medicineDal.Add(medicine);
            return new SuccessResult(Message.Success);
        }

        [AuthorizationAspect("IMedicineService.Delete,IMedicineService")]
        [CacheRemoveAspect("IMedicineService.Get")]
        public IResult Delete(Medicine medicine)
        {
            var result = BusinessRules.Run(CheckIfOwnerMedicine(medicine));
            if (result != null)
                return result;
            _medicineDal.Delete(medicine);
            return new SuccessResult(Message.Success);
        }
        [CacheAspect(60)]
        public IDataResult<List<Medicine>> GetMedicines()
        {
            var data = _medicineDal.GetAll();
            if (data.Count == 0)
            {
                return new ErrorDataResult<List<Medicine>>(Message.ThereIsNoSuchData);
            }
            return new SuccessDataResult<List<Medicine>>(data, Message.Success);
        }

        [CacheAspect(60)]
        public IDataResult<List<Medicine>> GetMedicinesBySupplierId(int supplierId)
        {
            var data = _medicineDal.GetAll(d => d.SupplierId == supplierId);
            if (data.Count == 0)
            {
                return new ErrorDataResult<List<Medicine>>(Message.ThereIsNoSuchData);
            }
            return new SuccessDataResult<List<Medicine>>(data, Message.Success);
        }

        [CacheAspect(60)]
        public IDataResult<List<Medicine>> GetMedicinesWithoutPrescription()
        {
            var data = _medicineDal.GetAll(d => d.IsPrescription == false);
            if (data.Count == 0)
            {
                return new ErrorDataResult<List<Medicine>>(Message.ThereIsNoSuchData);
            }
            return new SuccessDataResult<List<Medicine>>(data, Message.Success);
        }

        [CacheAspect(60)]
        public IDataResult<List<Medicine>> GetMedicinesWithPrescription()
        {
            var data = _medicineDal.GetAll(d => d.IsPrescription == true);
            if (data.Count == 0)
            {
                return new ErrorDataResult<List<Medicine>>(Message.ThereIsNoSuchData);
            }
            return new SuccessDataResult<List<Medicine>>(data, Message.Success);
        }

        [AuthorizationAspect("IMedicineService.Update,IMedicineService")]
        [ValidationAspect(typeof(DrugValidator))]
        [CacheRemoveAspect("IMedicineService.Get")]
        public IResult Update(Medicine medicine)
        {
            var result = BusinessRules.Run(
                CheckIfOwnerMedicine(medicine),
                CheckIfTITCKCodeExists(medicine.TITCKCode));

            if (result != null)
                return result;
            _medicineDal.Update(medicine);
            return new SuccessResult(Message.Success);
        }
        private IResult CheckIfMedicineNameExists(string name)
        {
            var result = _medicineDal.Get(d => d.Name == name);
            if (result is null)
                return new SuccessResult();
            return new ErrorResult(Message.SuchDataAlreadyExists);
        }
        private IResult CheckIfOwnerMedicine(Medicine medicine)
        {
            if(medicine.SupplierId != UserHelper.GetSupplierId())
            {
                return new ErrorResult(Message.TheDrugIsNotOwnedByYourCompany);
            }
            return new SuccessResult();
        }
        private IResult CheckIfTITCKCodeExists(string TITCKCode)
        {
            var result = _medicineDal.Get(d=>d.TITCKCode == TITCKCode);
            if (result is null)
                return new SuccessResult();
            return new ErrorResult(Message.SuchATITCKCodeAlreadyExists);
        }
    }
}
