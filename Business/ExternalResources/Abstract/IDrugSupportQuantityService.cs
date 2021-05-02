using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ExternalResources.Abstract
{
    public interface IDrugSupportQuantityService
    {
        IDataResult<double> GetSupportQuantityAsPercentage(int healtInsuranceType,string drugTITCKCode);
    }
}
