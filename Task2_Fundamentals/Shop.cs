using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2_Fundamentals
{
    public class Shop
    {
        static List<Product> Products; //list of products
        static List<string> Cumparate = new List<string>(5);
        public int budget;

        public Shop(int budget)
        {
            Products = new List<Product>(10);
            this.budget = budget;
        }

        /* search the product by its id and if it exists in the list we pop it */
        public bool BuyProduct(string choice)
        {
            int id = Int32.Parse(choice);

            foreach (var it in Products)
            {
                if (it.GetId() == id && (budget - it.GetPrice() >= 0))
                {
                    it.Stock--;
                    budget -= it.GetPrice();
                    Cumparate.Add(it.GetName());
                    if (it.Stock == 0) Products.Remove(it);
                    return true;
                }
            }
            return false;
        }

        /* print our list of products */
        public void PrintList(List<Product> list)
        {
            Console.WriteLine($"You have: {budget}");
            Console.WriteLine("List of products: ");
            foreach (var prod in Products)
            {
                Console.WriteLine(prod.ToString());
            }
        }

        public void PrintCumparate()
        {
            foreach (var prod in Cumparate)
            {
                Console.WriteLine(prod.ToString());
            }
        }

        /* verify if our list is empty */
        public bool IsEmpty()
        {
            return Products.Count == 0;
        }

        public void AddProduct(Product prod)
        {
           
                Products.Add(prod);
        }

        public void Startup()
        {
            PrintList(Products);
            Console.WriteLine("\n===== Hello customer!====\n");
            Console.WriteLine(" --> Please select your product that you want to buy by typing the product id. <--");
        }

        public void ReadProducts()
        {
            int id = 1;

            string nume;
            int pret = 0;
            int capacitate = 0;

            Console.WriteLine("Maybe you want to add some products...");
            Console.WriteLine("Do you want to proceed? Respond with y(Yes) or n(no)!");
            for (;Console.ReadLine() != "n" ; Console.WriteLine("Do you want to proceed? Respond with y(Yes) or n(no)!"))
            {
                Console.Write($"For product {id}: please enter the \n1. name = ");
                nume = Console.ReadLine();
                Console.Write("2. price = ");
                try
                {
                    pret = Int32.Parse(Console.ReadLine());
                    if (pret <= 0) throw new ArgumentException("You've entered a invalid price!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e);
                    continue;
                }
                
                Console.Write("3. capacity = ");
                try
                {
                    capacitate = Int32.Parse(Console.ReadLine());
                    if (capacitate <= 0) throw new ArgumentException("You've entered a invalid capacity!");
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e);
                    continue;
                }
                AddProduct(new Product(id, nume, pret, capacitate));
                id++;
            }
        }

        public void Customer()
        {
            string choice = "";

            for ( ;budget != 0; )
            {
                Console.Write("\nProduct id: ");
                choice = Console.ReadLine();
                if (IsEmpty() || choice == "q")
                {
                    break;
                }

                if (BuyProduct(choice))
                {
                    Console.WriteLine("Product bought! :)\n");

                    if(!IsEmpty()) PrintList(Products);
                }
                else
                {
                    Console.WriteLine("The product does not exist in the list or you do not have enought money to buy it! :(\n");
                    if (!IsEmpty())  PrintList(Products);
                }
                


            }
            
            
            Console.WriteLine("List of bought items: \n");
            PrintCumparate();
            Console.WriteLine("\n\nHave a nice day!");
        }
    }
}
