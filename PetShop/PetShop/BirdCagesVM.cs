using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class BirdCagesVM : INotifyPropertyChanged
    {
        public ObservableCollection<BirdCages> PetCollection { get; set; } = new ObservableCollection<BirdCages>();

        private BirdCages selectedPet;
        public BirdCages SelectedPet
        {
            get { return selectedPet; }
            set
            {
                selectedPet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPet"));
            }
        }

        public BirdCagesVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<BirdCages>()
            {
                new BirdCages("Fits 1 bird", "$150", 2, "Bird Cage",@"\Images\1_Bird_Cage.jpg","MK", "Queen", "two"),
                new BirdCages("Fits 2 bird", "$300", 3, "Bird Cage",@"\Images\2_bird_cage.jpg","MK", "King", "three"),
                new BirdCages("Fits 3 bird", "$200", 1, "Bird Cage",@"Images\3_Bird_cage.jpg","MK", "Full", "four")
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
