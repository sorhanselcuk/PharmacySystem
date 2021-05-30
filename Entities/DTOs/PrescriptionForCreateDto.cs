using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PrescriptionForCreateDto : IDto
    {
        public string PatientIdCardNumber { get; set; }
        public string DoctorRegistrationNumber { get; set; }
        public string HealtInstitutionNumber { get; set; }
        public List<DrugForPrescriptionDto> Drugs { get; set; }
    }

}