using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class DogBeds : bed
    {
        public string Form { get; set; } // Igloo, cave

        public DogBeds() { }

        public DogBeds(string description, string price, int stock, string name, string imagePath, string brand, string type, string form)
        : base(description, price, stock, name, imagePath, brand, type)
        {
            Form = form;
        }
    }
}
