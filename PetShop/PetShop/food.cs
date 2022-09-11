using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class food : Supplies
    {
        public string MainComponent { get; set; }

        public food() { }

        public food(string description, string price, int stock, string name, string imagePath, string brand, string maincomponent)
        : base(description, price, stock, name, imagePath,brand)
        {
            MainComponent = maincomponent;
        }
    }
}
