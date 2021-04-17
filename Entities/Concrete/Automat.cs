using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Entities.Concrete
{
    public class Automat:IEntity
    {
        public int Id { get; set; }
        public int TownId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
