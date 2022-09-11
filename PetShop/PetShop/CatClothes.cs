using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class CatClothes : clothes 
    {
        public string Form { get; set; } // Igloo, cave

        public CatClothes() { }

        public CatClothes(string description, string price, int stock, string name, string imagePath, string brand, string coatcolor, string form)
        : base(description, price, stock, name, imagePath, brand, coatcolor)
        {
            Form = form;
        }
    }
}
