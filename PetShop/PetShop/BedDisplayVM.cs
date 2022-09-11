using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class BedDisplayVM : INotifyPropertyChanged
    {
        public ObservableCollection<bed> PetCollection { get; set; } = new ObservableCollection<bed>();

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

        public BedDisplayVM()
        {
            ReadInDataFromXML();
        }

        private void ReadInDataFromXML()
        {

            PetCollection = new ObservableCollection<bed>()
            {
                new bed("Fits 1 bird", "$150", 2, "Bird Cage",@"\Images\1_Bird_Cage.jpg","MK", "Queen"),
                new bed("Fits 2 birds", "$300", 3, "Bird Cage 2",@"\Images\2_bird_cage.jpg","MK", "King"),
                new bed("Fits 3 birds", "$200", 1, "Bird Cage 3",@"\Images\3_Bird_cage.jpg","MK", "Full"),
                new bed("Very comfortable", "$3.70", 10, "Cat Cave Bed",@"\Images\cat_bed_cave.jpg","MK","Double"),
                new bed("very nice", "$3.70", 10, "Cat Igloo shaped Bed",@"\Images\cat_bed_igloo.jpg","MK","Double"),
                new bed("Comfortable", "$3.70", 10, "Couch Bed for Dogs",@"\Images\dog_bed_couch.jpg","MK","Double"),
                new bed("fancy", "$3.70", 10, "Fancy Dog Bed",@"\Images\dog_house_fancy.jpg","MK","Double"),
                new bed("Great product", "$3.70", 10, "Flat Dog Bed",@"\Images\dog_house_flat.jpg","MK","Double"),
                new bed("For smaller fish amounts", "$3.70", 10, "Fish Bowl",@"\Images\fish_bowl.jpg","MK","Double"),
                new bed("For larger fish amounts", "$3.70", 10, "Fish Tank",@"\Images\fish_tank.jpg","MK","Double")
            };
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }
}
