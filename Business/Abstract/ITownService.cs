using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITownService
    {
        IDataResult<List<Town>> GetAll();
        IDataResult<List<Town>> GetAllByCityId(int cityId);
        IDataResult<Town> GetTownById(int id);
    }
}
