using Core.Entities;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class PrescriptionForReturnDto : IDto
    {
        public List<DrugForPrescriptionDto> Drugs { get; set; }
    }
}
