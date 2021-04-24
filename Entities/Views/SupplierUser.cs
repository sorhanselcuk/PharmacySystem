using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Views
{
   public class SupplierUser:IView
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
