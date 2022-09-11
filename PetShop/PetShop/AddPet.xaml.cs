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
//    /// Interaction logic for AddPet.xaml
//    /// </summary>
//    public partial class AddPet : Window
//    {

//        List<Pets> list = new List<Pets>();
//        Pets p = new Pets();

//        public AddPet(List<Pets> petlist)
//        {
//            InitializeComponent();
//            list = petlist;

//            this.DataContext = p;

//        }

//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            //Pets p = new Pets();

//            //p.Name = name.Text;
//            //p.Price = price.Text;
//            //p.Stock = int.Parse(stock.Text);
//            //p.Description = description.Text;



//            list.Add(p);
//            //SellerWindow mw = new SellerWindow(list);
//            //mw.ShowDialog();
//            this.Close();

//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PetShop
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddPet : Window
    {
        Pets temporary = new Pets(); // creates a temporary student object
        Account current_user;
        ObservableCollection<Pets> pList = new ObservableCollection<Pets>();
        bool IsEdit;

        // Indicates that the AddPet window will have 1 student object passed to it
        public AddPet(ref Pets n, bool isEdit, ObservableCollection<Pets> PetList)
        {
            InitializeComponent();
            IsEdit = isEdit;
            pList = PetList;
            temporary = n; // makes temporary student object equal to the passed in student object
        }

        // This is responsible of the Add Education Details button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAllEntries())
            {
                if (IsEdit == true)
                {
                    Pets petToModify = pList.FirstOrDefault(x => x == temporary);
                    petToModify.Name = name.Text;
                    petToModify.Description = description.Text;
                    petToModify.Stock = Convert.ToInt32(stock.Text);
                    petToModify.Price = price.Text;
                }
                else
                {
                    temporary.Name = name.Text; // sets text input of last name equal to the first name student property
                    temporary.Description = description.Text; // sets text input of Uid equal to the SchoolID student property
                    temporary.Stock = Convert.ToInt32(stock.Text); // sets text input of last name equal to the last name student property
                    temporary.Price = price.Text; // sets text input of HomeAddress equal to the HomeAddress student property
                }

                this.Close();
            }

        }

        private bool ValidateAllEntries()
        {
            // validates school id
            //bool stockValid = string.IsNullOrWhiteSpace(stock.Text) ? false : ValidateFordigits(stock.Text, stock.MaxLength);
            //stock.Background = stockValid ? Brushes.White : Brushes.Coral;
            //stockWarning.Visibility = stockValid ? Visibility.Hidden : Visibility.Visible;

            // validates first name
            bool namevalid = string.IsNullOrWhiteSpace(name.Text) ? false : ValidateForLetters(name.Text);
            name.Background = namevalid ? Brushes.White : Brushes.Coral;
            nameWarning.Visibility = namevalid ? Visibility.Hidden : Visibility.Visible;

            return (namevalid);
        }

        // function validates for digits
        private bool ValidateFordigits(string tester, int maxlength)
        {
            return tester.Length == maxlength && tester.Where(x => char.IsDigit(x)).Count() == tester.Length;
        }

        // function validates for letters
        private bool ValidateForLetters(string tester)
        {
            return tester.Where(x => char.IsLetter(x)).Count() == tester.Length;
        }
    }
}
