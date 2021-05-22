using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Models;

namespace ShoppingCart
{
    public class DiscountA : IDiscount
    {
        public decimal ApplyDiscount(ProductDetail productDetail)
        {
            //3A's for 130
            var quantity = productDetail.Quantity;
            var baseDiscount = 130;
            int totalDiscount = 0;
            decimal totalPrice = 0;
            if (quantity >= 3)
            {
                totalDiscount = (quantity / 3) * baseDiscount;
                totalPrice = totalDiscount + ((quantity % 3) * productDetail.Price);                
            }
            else
            {
                totalPrice = productDetail.Quantity + productDetail.Price;
            }
            return totalPrice;
        }
    }
}
