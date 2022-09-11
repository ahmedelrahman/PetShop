using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class ClotheDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<clothes> PetCollection { get; set; } = new ObservableCollection<clothes>();

        private clothes selectedPet;
        public clothes SelectedPet
        {
            get { return selectedPet; }
            set
            {
                selectedPet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPet"));
            }
        }

        public ClotheDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<clothes>()
            {
                new clothes("Nice Jacket", "$150", 2, "Cat Jacket",@"\Images\cat_jacket.jpg","MK", "blue"),
                new clothes("Nice Shirt", "$300", 3, "Cat Red Shirt",@"\Images\cat_red_shirt.jpg","MK", "green"),
                new clothes("Cool Sweater", "$200", 1, "Dragon Sweter",@"\Images\dog_dragon_sweater.jpg","MK", "yellow"),
                new clothes("very nice fashion clothes", "$3.70", 10, "Professional Clothes",@"\Images\dog_fashion_clothes.jpg","MK","red")
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }
}
