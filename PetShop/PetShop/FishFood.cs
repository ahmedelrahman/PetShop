using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class FishFood : food
    {
        public string Form { get; set; } // pellet, frozen

        public FishFood() { }

        public FishFood(string description, string price, int stock, string name, string imagePath, string brand, string maincomponent, string form)
        : base(description, price, stock, name, imagePath, brand, maincomponent)
        {
            Form = form;
        }
    }
}
