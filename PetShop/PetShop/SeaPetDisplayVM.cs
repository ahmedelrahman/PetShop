using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class SeaPetDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<SeaPet> PetCollection { get; set; } = new ObservableCollection<SeaPet>();

        private SeaPet selectedPet;
        public SeaPet SelectedPet
        {
            get { return selectedPet; }
            set
            {
                selectedPet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPet"));
            }
        }

        public SeaPetDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<SeaPet>()
            {
                new SeaPet("Colorful","Colorful Fish", "$300", 3, "Colorful Fish",@"\Images\clown fish.jpg"),
                new SeaPet("Molly","silver with spot", "$200", 1, "Molly Pet Fish",@"\Images\molly.jpg"),
                new SeaPet("Platy","very nice fish", "$3.70", 10, "Platy Fish",@"\Images\platy.jpg"),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }
}
