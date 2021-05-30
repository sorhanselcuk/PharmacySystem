using Core.Entities;

namespace Entities.Views
{
    public class WebOperationClaim : IView
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
