using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Views;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfWebOperationClaimDal : EFViewRepositoryBase<WebOperationClaim, PharmacyAutomationDBContext>, IWebOperationClaimDal
    {
    }
}
