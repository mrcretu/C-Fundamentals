
namespace Task2_Fundamentals
{
    public class Product
    {
        private int ID;
        private string Name;
        private int Price;
        public int Stock;

        public Product(int id, string name, int price, int stock)
        {
            ID = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        override
        public string ToString()
        {
            string name_price = ID + ". " + Name + " with price: " + Price + ", capacity: " + Stock;
            return name_price;
        }

        public int GetId()
        {
            return ID;
        }
        public int GetPrice()
        {
            return Price;
        }
        public string GetName()
        {
            return Name;
        }
    }
}
