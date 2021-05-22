using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Models;

namespace ShoppingCart
{
    public interface IDiscount
    {
        decimal ApplyDiscount(ProductDetail productDetail);
    }
}
