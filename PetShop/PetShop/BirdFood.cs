using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class BirdFood : food
    {
        public string Form { get; set; } // Igloo, cave

        public BirdFood() { }

        public BirdFood(string description, string price, int stock, string name, string imagePath, string brand, string maincomponent, string form)
        : base(description, price, stock, name, imagePath, brand, maincomponent)
        {
            Form = form;
        }
    }
}
