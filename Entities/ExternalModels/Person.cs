using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ExternalModels
{
    public class Person
    {
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
