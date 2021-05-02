using Business.ExternalResources.Abstract;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ExternalResources.Concrete
{
    public class TITCKDrugSupportQuantityService : IDrugSupportQuantityService
    {
        public IDataResult<double> GetSupportQuantityAsPercentage(int healtInsuranceType, string drugTITCKCode)
        {
            throw new NotImplementedException();
        }
    }
}
