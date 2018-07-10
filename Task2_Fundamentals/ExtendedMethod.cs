using System;

namespace Task2_Fundamentals
{
    public static class ShopExtensions
    {

        /* search the product by its id and if it exists in the list we pop it */
        public static void ReadProducts(this Shop shop)
        {
            int id = 1;

            string nume;
            int pret = 0;
            int capacitate = 0;

            Console.WriteLine("Maybe you want to add some products...");
            Console.WriteLine("Do you want to proceed? Respond with y(Yes) or n(no)!");
            for (; Console.ReadLine() != "n"; Console.WriteLine("Do you want to proceed? Respond with y(Yes) or n(no)!"))
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
                catch (ArgumentException e)
                {
                    Console.WriteLine(e);
                    continue;
                }
                shop.AddProduct(new Product(id, nume, pret, capacitate));
                id++;
            }
        }

    }
}
