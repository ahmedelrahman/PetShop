using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class CatClothesDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<CatClothes> PetCollection { get; set; } = new ObservableCollection<CatClothes>();

        private CatClothes selectedPet;
        public CatClothes SelectedPet
        {
            get { return selectedPet; }
            set
            {
                selectedPet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPet"));
            }
        }

        public CatClothesDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<CatClothes>()
            {
                new CatClothes("Nice Jacket", "$150", 2, "Cat Jacket",@"\Images\cat_jacket.jpg","MK", "blue", "jacket"),
                new CatClothes("Nice Shirt", "$300", 3, "Cat Red Shirt",@"\Images\cat_red_shirt.jpg","MK", "green", "shirt"),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
