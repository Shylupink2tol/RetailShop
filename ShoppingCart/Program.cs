using System;
using System.Collections.Generic;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using ShoppingCart.Services;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {        
        static void Main(string[] args)
        {
            var shoppingRepository = new ShoppingRepository();
            var shoppingOperation = new ShoppingOperation(shoppingRepository);
            Console.WriteLine("Welcome to Retail Shop... Happy Shopping");
            var availableProducts = shoppingOperation.AddProducts();
            Console.WriteLine("------Product--------Price-------");
            foreach (var product in availableProducts)
            {
               
                Console.WriteLine($"        {product.Name}           {product.Price}");
            }

            Console.WriteLine("Please Enter Cart Items");
            var inputItems = Console.ReadLine();
            var cartItems= shoppingOperation.ProcessCartItems(inputItems);

            var productDetails = shoppingOperation.GetProductDetails(cartItems, availableProducts);

            var total = shoppingOperation.GetTotalBill(productDetails);

            Console.WriteLine("-------Qunatity * Product------ Price----");
            foreach (var item in productDetails)
            {
                Console.WriteLine($"-------{item.Quantity} * {item.Product} ----- {item.Price}-----");
            }

            Console.WriteLine($"-------Total --------------{total}-------");
            Console.ReadLine();

        }

       

    }
}
