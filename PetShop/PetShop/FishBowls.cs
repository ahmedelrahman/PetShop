using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class FishBowls : bed
    {
        public string Shape { get; set; }

        public FishBowls() { }

        public FishBowls(string description, string price, int stock, string name, string imagePath, string brand, string type, string shape)
        : base(description, price, stock, name, imagePath, brand, type)
        {
            Shape = shape;
        }
    }
}
