using Core.Entities;

namespace Entities.Concrete
{
    public class PrescriptionDetail : IEntity
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public int DrugId { get; set; }
        public int CountOfUsesPerDay { get; set; }
        public int CountOfDose { get; set; }
    }
}
