using Core.Entities;

namespace Entities.Concrete
{
    public class Town : IEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
    }
}
