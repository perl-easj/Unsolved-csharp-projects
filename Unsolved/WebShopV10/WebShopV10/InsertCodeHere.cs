using System;
using System.Collections.Generic;

namespace WebShopV10
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            List<double> itemPriceList = new List<double> { 12.0, 20.0, 75.0, 44.0, 15.0, 49.0 }; // 
            Order theOrder = new Order(itemPriceList);

            Console.WriteLine($"Order total cost is : {theOrder.TotalOrderPrice:F2} kr.");

            // The LAST line of code should be ABOVE this line
        }
    }
}