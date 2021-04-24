using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSupplierUserDal: EFViewRepositoryBase<SupplierUser, PharmacyAutomationDBContext>, ISupplierUserDal
    {
    }
}
