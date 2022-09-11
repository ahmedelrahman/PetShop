using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class FoodDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<food> PetCollection { get; set; } = new ObservableCollection<food>();

        private food selectedPet;
        public food SelectedPet
        {
            get { return selectedPet; }
            set
            {
                selectedPet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPet"));
            }
        }

        public FoodDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<food>()
            {
                new food("Nice MixedGrill Cat food", "$150", 2, "MixedGrill Cat Food",@"\Images\cat_food_mixedgrill.jpg","MK","beef"),
                new food("nice bird food", "$300", 3, "Bird Diet Food",@"\Images\diet_bird_food.jpg","MK","beef"),
                new food("Great grain free Cat food", "$200", 1, "Grain Free Cat Food",@"\Images\grain_free_cat_food.jpg","MK","corn"),
                new food("Food liked by many birds", "$3.70", 10, "Natural Bird Food",@"\Images\natural_bird_food.jpg","MK","beef"),
                new food("Natural Cat food", "$3.70", 10, "Natural Cat Food",@"\Images\natural_cat_food.jpg","MK","beef"),
                new food("Very good seed bird food", "$3.70", 10, "Bird Seed Food",@"\Images\seed_bird_food.jpg","MK","beef"),
                new food("very nice fish food", "$3.70", 10, "Fish Flakes",@"\Images\tetra_color_fish_flakes.jpg","MK","beef"),
                new food("Good Tropical fish food", "$3.70", 10, "Tropical Fish Flakes",@"\Images\tropical_fish_flakes.jpg","MK","beef"),
                new food("very nice dog food", "$3.70", 10, "Dog Food",@"\Images\v_dog_food.jpg","MK","beef")
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }
}

