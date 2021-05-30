using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Views;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSystemOperationClaimDal : EFViewRepositoryBase<SystemOperationClaim, PharmacyAutomationDBContext>, ISystemOperationClaimDal
    {
    }
}
