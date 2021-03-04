using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IDrugService
    {
        IResult Add(Drug drug);
        IResult Update(Drug drug);
        IDataResult<List<Drug>> GetDrugs();
        IDataResult<List<Drug>> GetDrugsBySupplierId(int supplierId);
        IDataResult<List<Drug>> GetDrugsWithPrescription();
        IDataResult<List<Drug>> GetDrugsWithoutPrescription();
    }
}
