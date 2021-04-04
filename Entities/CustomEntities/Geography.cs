using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.CustomEntities
{
    public class Geography
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString()
        {
            return $"geography::Point({Latitude},{Longitude},4326)";
        }
    }
}
