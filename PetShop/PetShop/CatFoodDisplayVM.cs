using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class CatFoodDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<CatFood> PetCollection { get; set; } = new ObservableCollection<CatFood>();

        private CatFood selectedPet;
        public CatFood SelectedPet
        {
            get { return selectedPet; }
            set
            {
                selectedPet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPet"));
            }
        }

        public CatFoodDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<CatFood>()
            {
                new CatFood("Nice MixedGrill Cat food", "$150", 2, "MixedGrill Cat Food",@"\Images\cat_food_mixedgrill.jpg","MK","beef", "pellets"),
                new CatFood("Great grain free Cat food", "$200", 1, "Grain Free Cat Food",@"\Images\grain_free_cat_food.jpg","MK","corn", "pellets"),
                new CatFood("Natural Cat food", "$3.70", 10, "Natural Cat Food",@"\Images\natural_cat_food.jpg","MK","beef", "pellets"),    
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
