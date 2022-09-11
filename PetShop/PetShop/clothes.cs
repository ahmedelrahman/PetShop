using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class clothes : Supplies
    {
        public string CoatColor { get; set; }

       // public string ShoeColor { get; set; }

        public clothes() { }

        public clothes(string description, string price, int stock, string name, string imagePath, string brand, string coatcolor)
        : base(description, price, stock, name, imagePath, brand)
        {
            CoatColor = coatcolor;
           // ShoeColor = shoecolor;
        }
    }
}
