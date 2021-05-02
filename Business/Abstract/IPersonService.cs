using Core.Utilities.Results.Abstract;
using Entities.ExternalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPersonService
    {
        IDataResult<Person> GetPerson(string idCardNumber);
    }
}
