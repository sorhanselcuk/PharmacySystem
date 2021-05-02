using Entities.ExternalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ExternalResources.Abstract
{
    public interface IIDService
    {
        Person GetPerson(string idCardNumber);
    }
}
