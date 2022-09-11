using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class FishBowlsDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<FishBowls> PetCollection { get; set; } = new ObservableCollection<FishBowls>();

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

        public FishBowlsDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<FishBowls>()
            {
                new FishBowls("For smaller fish amounts", "$3.70", 10, "Fish Bowl",@"\Images\fish_bowl.jpg","MK","Double","bowl"),
                new FishBowls("For larger fish amounts", "$3.70", 10, "Fish Tank",@"\Images\fish_tank.jpg","MK","Double","rectangle")
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
