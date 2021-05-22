using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public interface IShoppingRepository
    {
        List<Product> AddProducts();
    }
}
