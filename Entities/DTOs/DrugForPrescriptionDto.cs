using Core.Entities;

namespace Entities.DTOs
{
    public class DrugForPrescriptionDto : IDto
    {
        public int DrugId { get; set; }
        public int CountOfUsesPerDay { get; set; }
        public int CountOfDose { get; set; }
    }
}
