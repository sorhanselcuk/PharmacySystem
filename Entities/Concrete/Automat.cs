using Core.Entities;
using Entities.CustomEntities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Entities.Concrete
{
    public class Automat:IEntity
    {
        public int Id { get; set; }
        public int TownId { get; set; }
        public Geography Location { get; set; }
    }
}
