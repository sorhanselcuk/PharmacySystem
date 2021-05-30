using Core.Utilities.Results.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPrescriptionService
    {
        IResult CreatePrescription(PrescriptionForCreateDto prescriptionForCreateDto);
        
    }
}
