using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Models;

namespace ShoppingCart
{
    public class DiscountB : IDiscount
    {
        public decimal ApplyDiscount(ProductDetail productDetail)
        {
            //2Bs for 45
            var quantity = productDetail.Quantity;
            var baseDiscount = 45;
            int totalDiscount = 0;
            decimal totalPrice = 0;
            if (quantity >= 2)
            {
                totalDiscount = (quantity / 2) * baseDiscount;
                totalPrice = totalDiscount + ((quantity % 2) * productDetail.Price);
            }
            else
            {
                totalPrice = productDetail.Quantity + productDetail.Price;
            }
            return totalPrice;
        }
    }
}
