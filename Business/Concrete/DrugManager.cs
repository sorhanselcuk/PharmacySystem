using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class DrugManager : IDrugService
    {
        private IDrugDal _drugDal;

        public DrugManager(IDrugDal drugDal)
        {
            _drugDal = drugDal;
        }

        public IResult Add(Drug drug)
        {
            _drugDal.Add(drug);
            return new SuccessResult();
        }

        public IDataResult<List<Drug>> GetDrugs()
        {
            var data = _drugDal.GetAll();
            if (data is null)
            {
                return new ErrorDataResult<List<Drug>>();
            }
            return new SuccessDataResult<List<Drug>>(data);
        }

        public IDataResult<List<Drug>> GetDrugsBySupplierId(int supplierId)
        {
            var data = _drugDal.GetAll(d => d.SupplierId == supplierId);
            if (data is null)
            {
                return new ErrorDataResult<List<Drug>>();
            }
            return new SuccessDataResult<List<Drug>>(data);
        }

        public IDataResult<List<Drug>> GetDrugsWithoutPrescription()
        {
            var data = _drugDal.GetAll(d=>d.IsPrescription==true);
            if (data is null)
            {
                return new ErrorDataResult<List<Drug>>();
            }
            return new SuccessDataResult<List<Drug>>(data);
        }

        public IDataResult<List<Drug>> GetDrugsWithPrescription()
        {
            var data = _drugDal.GetAll(d => d.IsPrescription == true);
            if (data is null)
            {
                return new ErrorDataResult<List<Drug>>();
            }
            return new SuccessDataResult<List<Drug>>(data);
        }

        public IResult Update(Drug drug)
        {
            _drugDal.Add(drug);
            return new SuccessResult();
        }
    }
}
