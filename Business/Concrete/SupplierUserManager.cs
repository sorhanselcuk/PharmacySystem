using Business.Abstract;
using Business.Constants;
using Business.Utilities;
using Core.Aspects.Autofac.Security;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SupplierUserManager : ISupplierUserService
    {
        private ISupplierUserDal _supplierUserDal;

        public SupplierUserManager(ISupplierUserDal supplierUserDal)
        {
            _supplierUserDal = supplierUserDal;
        }

        [AuthorizationAspect("ISupplierUser")]
        public IDataResult<SupplierUser> GetUserByEmail(string eMail)
        {
            var data = _supplierUserDal.Get(u=>u.Email == eMail && u.SupplierId== UserHelper.GetSupplierId());
            if (data is null)
                return new ErrorDataResult<SupplierUser>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<SupplierUser>(data,Message.Success);
        }

        [AuthorizationAspect("ISupplierUser")]
        public IDataResult<List<SupplierUser>> GetUserByFullName(string fullName)
        {
            var data = _supplierUserDal.GetAll(u => u.FullName.Contains(fullName) && u.SupplierId == UserHelper.GetSupplierId());
            if (data.Count == 0)
                return new ErrorDataResult<List<SupplierUser>>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<List<SupplierUser>>(data, Message.Success);
        }

        [AuthorizationAspect("ISupplierUser")]
        public IDataResult<SupplierUser> GetUserById(int userId)
        {
            var data = _supplierUserDal.Get(u => u.Id == userId && u.SupplierId == UserHelper.GetSupplierId());
            if (data is null)
                return new ErrorDataResult<SupplierUser>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<SupplierUser>(data, Message.Success);
        }

        [AuthorizationAspect("ISupplierUser")]
        public IDataResult<SupplierUser> GetUserByUserName(string userName)
        {
            var data = _supplierUserDal.Get(u => u.UserName == userName && u.SupplierId == UserHelper.GetSupplierId());
            if (data is null)
                return new ErrorDataResult<SupplierUser>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<SupplierUser>(data, Message.Success);
        }

        [AuthorizationAspect("ISupplierUser")]
        public IDataResult<List<SupplierUser>> GetUsers()
        {
            var data = _supplierUserDal.GetAll(u => u.SupplierId == UserHelper.GetSupplierId());
            if (data.Count == 0)
                return new ErrorDataResult<List<SupplierUser>>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<List<SupplierUser>>(data, Message.Success);
        }
    }
}
