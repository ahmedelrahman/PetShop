using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class DogBedsDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<DogBeds> PetCollection { get; set; } = new ObservableCollection<DogBeds>();

        private bed selectedPet;
        public bed SelectedPet
        {
            get { return selectedPet; }
            set
            {
                selectedPet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPet"));
            }
        }

        public DogBedsDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<DogBeds>()
            {
                new DogBeds("Comfortable", "$3.70", 10, "Couch Bed for Dogs",@"\Images\dog_bed_couch.jpg","MK","Double", "couch"),
                new DogBeds("fancy", "$3.70", 10, "Fancy Dog Bed",@"\Images\dog_house_fancy.jpg","MK","Double", "fancy"),
                new DogBeds("Great product", "$3.70", 10, "Flat Dog Bed",@"C:\Images\dog_house_flat.jpg","MK","Double", "flat"),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
