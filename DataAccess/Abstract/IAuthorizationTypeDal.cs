using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAuthorizationTypeDal : IEntityRepository<AuthorizationType>
    {
    }
   
}
