using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Models;

namespace ShoppingCart
{
    public class NoDiscount : IDiscount
    {
        public decimal ApplyDiscount(ProductDetail productDetail)
        {
            return productDetail.Quantity* productDetail.Price;
        }
    }
}
