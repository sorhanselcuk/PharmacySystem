﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Views
{
    public class SystemOperationClaim:IView
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
