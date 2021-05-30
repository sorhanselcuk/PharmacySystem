namespace Core.Entities.Concrete
{
    public class AuthorizationType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
