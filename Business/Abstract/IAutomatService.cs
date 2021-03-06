using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAutomatService
    {
        IResult Add(Automat automat);
        IResult Update(Automat automat);
        IResult Delete(Automat automat);
        IDataResult<Automat> GetById(int id);
        IDataResult<List<Automat>> GetAll();
        IDataResult<List<Automat>> GetByTownId(int townId);
    }
}
