using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class bed : Supplies
    {
        public string Type { get; set; }

        public bed() { }

        public bed(string description, string price, int stock, string name, string imagePath, string brand, string type)
        : base(description, price, stock, name, imagePath, brand)
        {
            Type = type;
        }
    }
}
