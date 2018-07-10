using System;

namespace Task2_Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
         

            Console.Write("Enter your budget: ");
            var budget = Console.ReadLine();

            Shop myShop = new Shop(Int32.Parse(budget));
            

            //myShop.AddProduct(product1, product2, product3); //add products

        
            myShop.ReadProducts(); //add products
            myShop.Startup(); //print start info
            myShop.Customer();
        }
    }
}
