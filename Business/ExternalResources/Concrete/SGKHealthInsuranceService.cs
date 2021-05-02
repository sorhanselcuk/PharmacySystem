using Business.ExternalResources.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.ExternalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ExternalResources.Concrete
{
    public class SGKHealthInsuranceService : IHealthInsuranceService
    {
        public IDataResult<HealthInsuranceType> GetHealtInsuranceType(string nationalIdentityNumber)
        {
            throw new NotImplementedException();
        }
    }
}
