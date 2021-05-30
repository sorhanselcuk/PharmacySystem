using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class OperationClaim:IEntity
    {
        public int Id { get; set; }
        public int AuthorizationTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
