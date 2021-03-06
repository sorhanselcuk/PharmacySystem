using Core.Entities;


namespace Entities.Concrete
{
    public class AutomatStockInformation : IEntity
    {
        public int Id { get; set; }
        public int AutomatId { get; set; }
        public int DrugId { get; set; }
        public int UnitsInStock { get; set; }
    }
}
