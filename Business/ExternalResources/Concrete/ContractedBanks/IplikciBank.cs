using Business.ExternalResources.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.ExternalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ExternalResources.Concrete.ContractedBanks
{
    public class IplikciBank : IBank
    {
        public IResult Payment(PaymentInfo paymentInfo)
        {
            throw new NotImplementedException();
        }
    }
}
