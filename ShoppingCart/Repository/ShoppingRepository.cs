using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public class ShoppingRepository : IShoppingRepository
    {
        List<Product> products = new List<Product>();
        public List<Product> AddProducts()
        {
            products.Add(new Product { Name = "A", Price = 50, DiscountType = "DiscountA" });
            products.Add(new Product { Name = "B", Price = 30, DiscountType = "DiscountB" });
            products.Add(new Product { Name = "C", Price = 20, DiscountType = "DiscountCD" });
            products.Add(new Product { Name = "D", Price = 15, DiscountType = "DiscountCD" });
            return products;

        }
    }
}
