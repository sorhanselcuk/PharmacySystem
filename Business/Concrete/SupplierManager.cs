using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SupplierManager : ISupplierService
    {
        private ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        [ValidationAspect(typeof(SupplierValidator))]
        public IResult Add(Supplier supplier)
        {
            var result = BusinessRules.Run(
                CheckIfSupplierNameExists(supplier.Name),
                CheckIfSupplierEMailExists(supplier.Email));

            if (result != null)
                return result;

            _supplierDal.Add(supplier);
            return new SuccessResult(Message.Success);
        }

        public IResult Delete(Supplier supplier)
        {
            _supplierDal.Delete(supplier);
            return new SuccessResult(Message.Success);
        }

        public IDataResult<List<Supplier>> GetSuppliers()
        {
            var data = _supplierDal.GetAll();
            if(data is null)
            {
                return new ErrorDataResult<List<Supplier>>(Message.ThereIsNoSuchData);
            }
            return new SuccessDataResult<List<Supplier>>(data,Message.Success);
        }

        [ValidationAspect(typeof(SupplierValidator))]
        public IResult Update(Supplier supplier)
        {
            var result = BusinessRules.Run(
               CheckIfSupplierNameExists(supplier.Name),
               CheckIfSupplierEMailExists(supplier.Email));

            if (result != null)
                return result;
            _supplierDal.Update(supplier);
            return new SuccessResult(Message.Success);
        }
        
        private IResult CheckIfSupplierEMailExists(string eMail)
        {
            var result = _supplierDal.Get(s=>s.Email == eMail);
            if (result is null)
                return new SuccessResult();
            return new ErrorResult(Message.SuchAEMailAlreadyExists);
        }
        private IResult CheckIfSupplierNameExists(string name)
        {
            var result = _supplierDal.Get(s => s.Name == name);
            if (result is null)
                return new SuccessResult();
            return new ErrorResult(Message.SuchDataAlreadyExists);
        }
    }
}
