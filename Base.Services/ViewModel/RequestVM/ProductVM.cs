﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services.ViewModel.RequestVM
{
    public class ProductVM
    {
        public string? ProductName { get; set; }
        public int? Quantity { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public string? Capacity { get; set; }
        public string? Brand { get; set; }
        public double? Price { get; set; }
        public int? CategoryId { get; set; }
    }
}
