using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class DogClothesDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<DogClothes> PetCollection { get; set; } = new ObservableCollection<DogClothes>();

        private DogClothes selectedPet;
        public DogClothes SelectedPet
        {
            get { return selectedPet; }
            set
            {
                selectedPet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPet"));
            }
        }

        public DogClothesDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<DogClothes>()
            {
                new DogClothes("Cool Sweater", "$200", 1, "Dragon Sweter",@"\Images\dog_dragon_sweater.jpg","MK", "yellow", "Sweater"),
                new DogClothes("very nice fashion clothes", "$3.70", 10, "Professional Clothes",@"\Images\dog_fashion_clothes.jpg","MK","red", "Nice Shirt")
            };
        }
        

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
