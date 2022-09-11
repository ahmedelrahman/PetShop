using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class PetDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<LandPet> PetCollection { get; set; } = new ObservableCollection<LandPet>();

        private Pets selectedPet;
        public Pets SelectedPet
        {
            get { return selectedPet; }
            set
            {
                selectedPet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPet"));
            }
        }

        public PetDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<LandPet>()
            {
                new LandPet("Colorful Parrot", "$150", 2, "Parrot",@"\Images\Parrot.jpg","blue",5),
                new LandPet("Cute Puppy", "$300", 3, "Golden Retriever Puppy",@"\Images\Golden Retriever.jpg", "yellow", 4),
                new LandPet("Striped Cat", "$200", 1, "Cat",@"\Images\Cat.jpg", "orange", 8),
                new LandPet("very nice nemo fish", "$3.70", 10, "Clown Fish",@"\Images\clown fish.jpg", "maroon", 7),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }
}
    
