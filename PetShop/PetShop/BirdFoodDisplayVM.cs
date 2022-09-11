using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class BirdFoodDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<BirdFood> PetCollection { get; set; } = new ObservableCollection<BirdFood>();

        private BirdFood selectedPet;
        public BirdFood SelectedPet
        {
            get { return selectedPet; }
            set
            {
                selectedPet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPet"));
            }
        }

        public BirdFoodDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<BirdFood>()
            {

                new BirdFood("Excellent Food", "$3.70", 10, "Seed Bird Food",@"\Images\seed_bird_food.jpg","MK","beef", "seeds"),
                new BirdFood("Food liked by many birds", "$3.70", 10, "Natural Bird Food",@"\Images\natural_bird_food.jpg","MK","beef", "pellets"),
                new BirdFood("nice bird food", "$300", 3, "Bird Diet Food",@"\Images\diet_bird_food.jpg","MK","beef", "pellets")
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
