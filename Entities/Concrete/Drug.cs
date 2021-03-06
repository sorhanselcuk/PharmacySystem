using Core.Entities;

namespace Entities.Concrete
{
    public class Drug : IEntity
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public bool IsPrescription { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
