using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Models;

namespace ShoppingCart.Services
{
    public interface IShoppingOperation
    {
        List<Product> AddProducts();

        List<Cart> ProcessCartItems(string inputItems);

        decimal GetTotalBill(List<ProductDetail> productDetails);

        List<ProductDetail> GetProductDetails(List<Cart> cartItems, List<Product> products);

    }
}
