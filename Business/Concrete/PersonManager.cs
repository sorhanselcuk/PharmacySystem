using Business.Abstract;
using Business.Constants;
using Business.ExternalResources.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.ExternalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private IIDService _idService;

        public PersonManager(IIDService idService)
        {
            _idService = idService;
        }

        public IDataResult<Person> GetPerson(string idCardNumber)
        {
            var person = _idService.GetPerson(idCardNumber);
            if (person is null)
                return new ErrorDataResult<Person>(Message.ThereIsNoSuchData);
            return new SuccessDataResult<Person>(person, Message.Success);
        }
    }
}
