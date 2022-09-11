using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class LandPet : SuperPet
    {
        public string FurColor { get; set; }

        public int LoyaltyLevel { get; set; }

        public LandPet() { }

        public LandPet(string description, string price, int stock, string name, string imagePath, string furcolor, int loyaltylevel)
        : base(description, price, stock, name, imagePath)
        {
            //Description = description;
            //Price = price;
            //Stock = stock;
            //Name = name;
            //ImagePath = imagePath;
           

            FurColor = furcolor;
            LoyaltyLevel = loyaltylevel;
        }


    }
}
