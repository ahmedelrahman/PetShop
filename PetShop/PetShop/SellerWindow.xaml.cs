//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

//namespace PetShop
//{
//    /// <summary>
//    /// Interaction logic for SellerWindow.xaml
//    /// </summary>
//    public partial class SellerWindow : Window
//    {
//        List<Pets> petslist = new List<Pets>();
//        public SellerWindow(List<Pets> pList)
//        {
//            InitializeComponent();
//           // petslist[0].Name = "Q";
//            this.DataContext = pList;
//            //petslist = pList;
//        }

//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            AddPet newpet = new AddPet(petslist);
//            newpet.ShowDialog();
//        }

//        private void Button_Click_1(object sender, RoutedEventArgs e)
//        {

//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace PetShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SellerWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Pets> petslist = new ObservableCollection<Pets>();

        Account currentUser;
        List<Account> Users = new List<Account>();

        XmlSerializer serializer = new XmlSerializer(typeof(List<Account>));

        private Pets _SelectedCustomer;
        public Pets SelectedCustomer
        {
            get { return _SelectedCustomer; }
            set
            {
                _SelectedCustomer = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCustomer"));
            }
        }

        private ObservableCollection<Pets> _customercollection;

        public ObservableCollection<Pets> CustomerCollection
        {
            get { return _customercollection; }
            set
            {
                _customercollection = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCustomer"));
            }
        }

        public SellerWindow(Account CurrentUser, List<Account> UsersList)
        {
            //GetCustomersFromXML();
            InitializeComponent();
            DataContext = this;
            currentUser = CurrentUser;
            Users = UsersList;
            GetCustomersFromXML();
        }

        private void GetCustomersFromXML()
        {
            //CustomerCollection = new List<Pets>()
            //{
            //    new Pets("Tom", "Jones", 64764, "Meadows Lane", "Tampa"),
            //    new Pets("Bill","Smith", 64764, "Mid rd", "Orlando"),
            //    new Pets("Will","Smith", 64764, "Meadows Lane", "Tampa"),
            //    new Pets("Mike", "Woods", 64764, "Meadows Lane", "Tampa"),
            //    new Pets("Blob", "Jims", 64764, "Meadows Lane", "Tampa"),
            //    new Pets("Sarah", "Johns", 54367, "Tree house", "Tampa")
            //};

            //string path = "petslist.xml";

            //if (File.Exists(path))
            //{
            //    using (FileStream readStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            //    {
            //        CustomerCollection = serializer.Deserialize(readStream) as ObservableCollection<Pets>;
            //    }
            //}

            if (currentUser.petsToSell != null)
            {
                CustomerCollection = currentUser.petsToSell;
            }
        }

        int n;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //            AddPet newpet = new AddPet(petslist);
            //            newpet.ShowDialog();

            Pets n_pet = new Pets(); // creates a new student object
            AddPet s = new AddPet(ref n_pet, false, currentUser.petsToSell); // creates the AddStudent Window and passes the student object to it
            s.ShowDialog(); // displays the newly made AddStudent window
            if (n_pet.Name != null && n_pet.Description != null)
            {
                currentUser.petsToSell.Add(n_pet); // adds the student to the list after the user fills out their properties on different windows on this application
                n = 0;
            }
            else
            {
                n = 1;
            }

            string path = "Users.xml";
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    serializer.Serialize(fs, Users);
                }
            }
            // file name
            //string path = "petslist.xml";

            //// if nothing is in the file
            //if (petslist.Count == 0 && File.Exists(path))
            //{
            //    File.Delete(path);
            //}
            //else
            //{
            //    // if a student has been recently added by the user
            //    if (petslist.Count != 0 && n == 0)
            //    {
            //        using (FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            //        {
            //            serializer.Serialize(filestream, petslist);
            //        }

            //        MessageBox.Show("Your file is up to date!", "Success!!"); //Pop up
            //    }

            //    // If the user did not add a student
            //    if (petslist.Count != 0 && n != 0)
            //    {
            //        using (FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            //        {
            //            serializer.Serialize(filestream, petslist);
            //        }

            //        MessageBox.Show("No Student has been added but existing students are still in the file", "Success!!"); //Pop up
            //    }
            //}

        }

        // This is responsible of the functionality of the AddStudent button
        private void DeletePet(object sender, RoutedEventArgs e)
        {
            // makes sure that the list view has an object that is clicked on by the user
            if (PetCollection.SelectedItem != null)
            {
                // sets myString equal to the string form of the student clicked on by the user
                string myString = PetCollection.SelectedItem.ToString();

                GetCustomersFromXML();

                // loop in charge of removing the clicked clicked item off the main list saving all the students
                for (int i = 0; i < currentUser.petsToSell.Count; i++)
                {
                    Pets pet = currentUser.petsToSell[i];
                    if (pet.ToString() == myString)
                    {
                        currentUser.petsToSell.Remove(pet);
                    }
                }

                string path = "Users.xml";

                using (FileStream filestream = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite))
                {
                    serializer.Serialize(filestream, Users);
                }

                //if (realList.Count == 0)
                //{
                //    File.Delete(path);
                //}

                // in charge of removing the clicked item off the list displayed in the Listview
                CustomerCollection.Remove(PetCollection.SelectedItem as Pets);


            }
        }

        
        //private void CustomerChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    SelectedCustomer = CustomerCombo.SelectedItem as Pets;
        //}


        private void EditPet(object sender, RoutedEventArgs e)
        {
            Pets n_pet = PetCollection.SelectedItem as Pets; // creates a new student object
            AddPet s = new AddPet(ref n_pet, true, currentUser.petsToSell); // creates the AddStudent Window and passes the student object to it
            s.ShowDialog(); // displays the newly made AddStudent window
            //if (n_pet.Name != null && n_pet.Description != null)
            //{
            //    currentUser.petsToSell.Add(n_pet); // adds the student to the list after the user fills out their properties on different windows on this application
            //    n = 0;
            //}
            //else
            //{
            //    n = 1;
            //}

            

            string path = "Users.xml";
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    serializer.Serialize(fs, Users);
                }
            }

            GetCustomersFromXML();
            // SellerWindow.ref
            CollectionViewSource.GetDefaultView(PetCollection.ItemsSource).Refresh();
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void logout(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            this.Close();
            l.ShowDialog();
        }
    }
}
