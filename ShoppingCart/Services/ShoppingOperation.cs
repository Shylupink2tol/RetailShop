using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingCart.Models;
using ShoppingCart.Repository;

namespace ShoppingCart.Services
{
    
    public class ShoppingOperation : IShoppingOperation
    {
        List<Product> products = new List<Product>();
        IShoppingRepository _shoppingRepository;

        public ShoppingOperation(IShoppingRepository shoppingRepository)
        {
            _shoppingRepository = shoppingRepository;
        }
        public List<Product> AddProducts()
        {
            
            return _shoppingRepository.AddProducts();

        }

        public List<Cart> ProcessCartItems(string inputItems)
        {
            var cartItems = new List<Cart>();
            var inputCartItems = inputItems.Split(',');
            foreach (var item in inputCartItems)
            {
                if (cartItems.Any(x => x.Product == item))
                {
                    var quantity = cartItems.FirstOrDefault(x => x.Product == item).Quantity;
                    quantity++;
                    cartItems.Where(x => x.Product == item).ToList().ForEach(x => x.Quantity = quantity);
                }
                else
                {
                    var cart = new Cart { Product = item, Quantity = 1 };
                    cartItems.Add(cart);
                }
            }
            return cartItems;
        }

        public decimal GetTotalBill(List<ProductDetail> productDetails)
        {
            decimal total = 0;
            
            foreach (var item in productDetails)
            {
                total += item.Price;
            }
            return total;
        }

        public List<ProductDetail> GetProductDetails(List<Cart> cartItems, List<Product> products)
        {
            var productDetails = new List<ProductDetail>();

            foreach (var item in cartItems)
            {
                if(products.Any(x=>x.Name == item.Product))
                {
                    var product = products.First(x => x.Name == item.Product);
                    var productDetail = new ProductDetail();
                    productDetail.Product = item.Product;
                    productDetail.Quantity = item.Quantity;
                    if (string.IsNullOrEmpty(product.DiscountType))
                    {
                        productDetail.Price =  item.Quantity * product.Price;
                    }

                    //ProcessDiscountLogic
                    productDetails.Add(productDetail);
                }
            }
            return productDetails;
        }
    }
}
