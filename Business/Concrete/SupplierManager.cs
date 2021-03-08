using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Supplier supplier)
        {
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

        public IResult Update(Supplier supplier)
        {
            _supplierDal.Update(supplier);
            return new SuccessResult(Message.Success);
        }
    }
}
