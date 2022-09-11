using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    abstract public class Supplies
    {
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int Stock { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int PurchasedAmount { get; set; }

        public Supplies() { }

        public Supplies(string description, string price, int stock, string name, string imagePath, string brand)
        {
            Description = description;
            Price = price;
            Stock = stock;
            Name = name;
            ImagePath = imagePath;
            Brand = brand;
        }
    }
}
