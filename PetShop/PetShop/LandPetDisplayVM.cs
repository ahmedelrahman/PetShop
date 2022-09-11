using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class LandPetDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<LandPet> PetCollection { get; set; } = new ObservableCollection<LandPet>();

        private LandPet selectedPet;
        public LandPet SelectedPet
        {
            get { return selectedPet; }
            set
            {
                selectedPet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPet"));
            }
        }

        public LandPetDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<LandPet>()
            {
                new LandPet("Colorful Parrot", "$150", 2, "Parrot",@"\Images\Parrot.jpg","blue",5),
                new LandPet("Cute Puppy", "$300", 3, "Golden Retriever Puppy",@"\Images\Golden Retriever.jpg","green",6),
                new LandPet("Striped Cat", "$200", 1, "Cat",@"\Images\Cat.jpg","yellow",7),
                new LandPet("Impressive Dog", "$370", 10, "Beagle Dog",@"\Images\Beagle.jpg","grey",7)
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }
}
