using Core.Utilities.Results.Abstract;
using Entities.ExternalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ExternalResources.Abstract
{
    public interface IBank
    {
        IResult Payment(PaymentInfo paymentInfo);
    }
}
