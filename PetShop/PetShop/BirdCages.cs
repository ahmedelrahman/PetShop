using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class BirdCages : bed
    {
        public string Capacity { get; set; }

        public BirdCages() { }

        public BirdCages(string description, string price, int stock, string name, string imagePath, string brand, string type, string capacity)
        : base(description, price, stock, name, imagePath, brand, type)
        {
            Capacity = capacity;
        }
    }
}
