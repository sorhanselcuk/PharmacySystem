using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAutomatStockInformationService
    {
        IDataResult<AutomatStockInformation> GetById(int automatId);
    }
}
