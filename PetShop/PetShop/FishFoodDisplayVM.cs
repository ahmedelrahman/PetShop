using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class FishFoodDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<FishFood> PetCollection { get; set; } = new ObservableCollection<FishFood>();

        private FishFood selectedPet;
        public FishFood SelectedPet
        {
            get { return selectedPet; }
            set
            {
                selectedPet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPet"));
            }
        }

        public FishFoodDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<FishFood>()
            {
                new FishFood("very nice fish food", "$3.70", 10, "Clown Fish",@"\Images\tetra_color_fish_flakes.jpg","MK","beef", "flakes"),
                new FishFood("Good Tropical fish food", "$3.70", 10, "Clown Fish",@"\Images\tropical_fish_flakes.jpg","MK","beef", "flakes"),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
