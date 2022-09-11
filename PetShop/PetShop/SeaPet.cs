using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class SeaPet : SuperPet
    {
        public string FishType { get; set; }

        public SeaPet() { }

        public SeaPet(string fishtype, string description, string price, int stock, string name, string imagePath)
        : base(description, price, stock, name, imagePath)
        {
            //Description = description;
            //Price = price;
            //Stock = stock;
            //Name = name;
            //ImagePath = imagePath;


            FishType = fishtype;
        }
    }
}
