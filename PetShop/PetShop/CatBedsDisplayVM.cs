using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class CatBedsDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<CatBeds> PetCollection { get; set; } = new ObservableCollection<CatBeds>();

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

        public CatBedsDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<CatBeds>()
            {
                new CatBeds("Nice Cats Bed", "$300", 3, "Golden Retriever Puppy",@"\Images\Golden Retriever.jpg","MK", "Queen", "Igloo"),
                new CatBeds("very nice", "$3.70", 10, "Cat Igloo shaped Bed",@"\Images\cat_bed_igloo.jpg","MK","Double", "Igloo"),
                new CatBeds("Very comfortable", "$3.70", 10, "Cat Cave Bed",@"\Images\cat_bed_cave.jpg","MK","Double", "Cave"),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }
}

