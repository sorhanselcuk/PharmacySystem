using Core.Utilities.Results.Abstract;
using Entities.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISupplierUserService
    {
        public IDataResult<List<SupplierUser>> GetUsers();
        public IDataResult<SupplierUser> GetUserById(int userId);
        public IDataResult<SupplierUser> GetUserByUserName(string userName);
        public IDataResult<SupplierUser> GetUserByEmail(string eMail);
        public IDataResult<List<SupplierUser>> GetUserByFullName(string fullName);
    }
}
