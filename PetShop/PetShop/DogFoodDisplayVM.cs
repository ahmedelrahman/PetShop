using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class DogFoodDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<DogFood> PetCollection { get; set; } = new ObservableCollection<DogFood>();

        private DogFood selectedPet;
        public DogFood SelectedPet
        {
            get { return selectedPet; }
            set
            {
                selectedPet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPet"));
            }
        }

        public DogFoodDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<DogFood>()
            {
                new DogFood("very nice dog food", "$3.70", 10, "Dog Food",@"\Images\v_dog_food.jpg","MK","beef", "vegeterian"),
                new DogFood("Excellent dog food", "$3.70", 10, "Dog Food",@"\Images\dog_food_with_beef.jpg","MK","beef", "vegeterian"),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
