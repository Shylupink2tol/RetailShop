﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string DiscountType { get; set; }
    }
}
