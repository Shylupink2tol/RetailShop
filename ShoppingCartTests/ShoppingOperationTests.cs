using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using ShoppingCart.Services;
using Xunit;

namespace ShoppingCartTests
{
    public class ShoppingCartDiscounts

    {
        [Fact]
        public void Test_ShoppingOperation_ShowAvailableProducts()
        {
            
            var mockShoppingRepository = new Mock<IShoppingRepository>();
            List<Product> mockProducts = new List<Product>();
            mockProducts.Add(new Product { Name = "A", Price = 50, DiscountType = "DiscountA" });
            mockProducts.Add(new Product { Name = "B", Price = 30, DiscountType = "DiscountB" });

            mockShoppingRepository.Setup(x => x.AddProducts()).Returns(mockProducts);

            var shoppingOperation = new ShoppingOperation(mockShoppingRepository.Object);
            var availableProducts =  shoppingOperation.AddProducts();
            Assert.True(availableProducts.Count == 2);
            Assert.True(availableProducts[0].Name == "A");
            Assert.True(availableProducts[0].Price == 50);
            Assert.True(availableProducts[0].DiscountType == "DiscountA");

        }

        [Theory]
        [InlineData("A,B,A,C,B,D", 4,2,2,1,1)]
        [InlineData("A,B,C,D", 4, 1, 1, 1, 1)]
        [InlineData("A,A,A,B,B,C,D,D", 4, 3, 2, 1, 2)]
        public void Test_ShoppingOperation_WhenMultipleProductOfSameTypeIsAdded_ProcessCartItems(string input, int count, int out1, int out2, int out3, int out4)
        {
            var mockShoppingRepository = new Mock<IShoppingRepository>();
            var shoppingOperation = new ShoppingOperation(mockShoppingRepository.Object);

           
           var cartItems = shoppingOperation.ProcessCartItems(input);

            Assert.True(cartItems.Count == count);
            Assert.True(cartItems.FirstOrDefault(x => x.Product == "A").Quantity == out1);
            Assert.True(cartItems.FirstOrDefault(x => x.Product == "B").Quantity == out2);
            Assert.True(cartItems.FirstOrDefault(x => x.Product == "C").Quantity == out3);
            Assert.True(cartItems.FirstOrDefault(x => x.Product == "D").Quantity == out4);
        }

        [Fact]
        public void Test_ShoppingOperation_WhenNoDiscountIsApplied_DisplayBasePrice()
        {
            var mockShoppingRepository = new Mock<IShoppingRepository>();
            var shoppingOperation = new ShoppingOperation(mockShoppingRepository.Object);

            var cartItems = new List<Cart>();
            cartItems.Add(new Cart { Product = "A", Quantity = 2 });
            cartItems.Add(new Cart { Product = "B", Quantity = 1 });

            var products = new List<Product>();
            products.Add(new Product { Name = "A", Price = 50, DiscountType = "" });
            products.Add(new Product { Name = "B", Price = 30, DiscountType = null });

            var productDetails = shoppingOperation.GetProductDetails(cartItems, products);

            Assert.True(productDetails.Count == 2);
            Assert.True(productDetails.First(x => x.Product == "A").Price == 100);
            Assert.True(productDetails.First(x => x.Product == "B").Price == 30);
        }

        [Fact]
        public void Test_ShoppingOperation_WhenDiscountAIsApplied_DisplayDiscountedPrice()
        {
            var mockShoppingRepository = new Mock<IShoppingRepository>();
            var shoppingOperation = new ShoppingOperation(mockShoppingRepository.Object);

            var cartItems = new List<Cart>();
            cartItems.Add(new Cart { Product = "A", Quantity = 3 });
            cartItems.Add(new Cart { Product = "B", Quantity = 1 });

            var products = new List<Product>();
            products.Add(new Product { Name = "A", Price = 50, DiscountType = "DiscountA" });
            products.Add(new Product { Name = "B", Price = 30, DiscountType = null });

            var productDetails = shoppingOperation.GetProductDetails(cartItems, products);

            Assert.True(productDetails.Count == 2);
            Assert.True(productDetails.First(x => x.Product == "A").Price == 130);
            Assert.True(productDetails.First(x => x.Product == "B").Price == 30);
        }

        [Fact]
        public void Test_ShoppingOperation_WhenDiscountBIsApplied_DisplayDiscountedPrice()
        {
            var mockShoppingRepository = new Mock<IShoppingRepository>();
            var shoppingOperation = new ShoppingOperation(mockShoppingRepository.Object);

            var cartItems = new List<Cart>();
            cartItems.Add(new Cart { Product = "A", Quantity = 5 });
            cartItems.Add(new Cart { Product = "B", Quantity = 2 });

            var products = new List<Product>();
            products.Add(new Product { Name = "A", Price = 50, DiscountType = "DiscountA" });
            products.Add(new Product { Name = "B", Price = 30, DiscountType = "DiscountB" });

            var productDetails = shoppingOperation.GetProductDetails(cartItems, products);

            Assert.True(productDetails.Count == 2);
            Assert.True(productDetails.First(x => x.Product == "A").Price == 230);
            Assert.True(productDetails.First(x => x.Product == "B").Price == 45);
        }

        [Fact]
        public void Test_ShoppingOperation_WhenCartIsSelected_GetTotalPrice()
        {
            var mockShoppingRepository = new Mock<IShoppingRepository>();
            var shoppingOperation = new ShoppingOperation(mockShoppingRepository.Object);

           

            var productDetails = new List<ProductDetail>();
            productDetails.Add(new ProductDetail { Product = "A", Price = 50, Quantity = 2});
            productDetails.Add(new ProductDetail { Product = "B", Price = 30, Quantity = 1 });

            var total = shoppingOperation.GetTotalBill(productDetails);

            Assert.True(total == 80);
        }
    }
}
