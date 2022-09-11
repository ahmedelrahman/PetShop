using System;
using System.Collections.Generic;
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

namespace PetShop 
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Account CurrentUser, List<Account> UsersList)
        {
            MainWindowViewModel mainWindow = new MainWindowViewModel(CurrentUser,UsersList);
            InitializeComponent();
            DataContext = mainWindow;
            UserCreds.Header = $"Logged in as: {CurrentUser.FirstName}";
        }

        private void refresh(object sender, RoutedEventArgs e)
        {
            if (PetSelection.SelectionBoxItem.ToString() == "Birds/ Parrots" && Supply.SelectionBoxItem.ToString() == "Beds")
            {
                BirdCages.Visibility = Visibility.Visible;
            }

            if (PetSelection.SelectionBoxItem.ToString() == "Cats" && Supply.SelectionBoxItem.ToString() == "Beds")
            {
                CatBeds.Visibility = Visibility.Visible;
            }

            if (PetSelection.SelectionBoxItem.ToString() == "Dogs" && Supply.SelectionBoxItem.ToString() == "Beds")
            {
                DogBeds.Visibility = Visibility.Visible;
            }

            if (PetSelection.SelectionBoxItem.ToString() == "Fish" && Supply.SelectionBoxItem.ToString() == "Beds")
            {
                FishBowl.Visibility = Visibility.Visible;
            }

            if (PetSelection.SelectionBoxItem.ToString() == "Fish" && Supply.SelectionBoxItem.ToString() == "Food")
            {
                Fish_Food.Visibility = Visibility.Visible;
            }

            if (PetSelection.SelectionBoxItem.ToString() == "Dogs" && Supply.SelectionBoxItem.ToString() == "Food")
            {
                Dog_Food.Visibility = Visibility.Visible;
            }

            if (PetSelection.SelectionBoxItem.ToString() == "Cats" && Supply.SelectionBoxItem.ToString() == "Food")
            {
                Cat_Food.Visibility = Visibility.Visible;
            }

            if (PetSelection.SelectionBoxItem.ToString() == "Birds/ Parrots" && Supply.SelectionBoxItem.ToString() == "Food")
            {
                Bird_Food.Visibility = Visibility.Visible;
            }

            if (PetSelection.SelectionBoxItem.ToString() == "Dogs" && Supply.SelectionBoxItem.ToString() == "Clothes")
            {
                Dog_Clothes.Visibility = Visibility.Visible;
            }

            if (PetSelection.SelectionBoxItem.ToString() == "Cats" && Supply.SelectionBoxItem.ToString() == "Clothes")
            {
                Cat_Clothes.Visibility = Visibility.Visible;
            }
        }

        private void logout(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            this.Close();
            l.ShowDialog();
        }
    }
}
