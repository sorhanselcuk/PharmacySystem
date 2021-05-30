using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Prescription:IEntity
    {
        public int Id { get; set; }
        public string PatientIdCardNumber { get; set; }
        public string DoctorRegistrationNumber { get; set; }
        public string HealtInstitutionNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
