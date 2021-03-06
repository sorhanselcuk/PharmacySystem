using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISupplierService
    {
        IResult Add(Supplier supplier);
        IResult Update(Supplier supplier);
        IResult Delete(Supplier supplier);
        IDataResult<List<Supplier>> GetSuppliers();
    }
}
