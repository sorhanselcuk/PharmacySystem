using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMedicineService
    {
        IResult Add(Medicine drug);
        IResult Update(Medicine drug);
        IResult Delete(Medicine drug);
        IDataResult<List<Medicine>> GetMedicines();
        IDataResult<List<Medicine>> GetMedicinesBySupplierId(int supplierId);
        IDataResult<List<Medicine>> GetMedicinesWithPrescription();
        IDataResult<List<Medicine>> GetMedicinesWithoutPrescription();
    }
}
