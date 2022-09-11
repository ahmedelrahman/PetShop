using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace PetShop
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public List<Account> UserList = new List<Account>();
        XmlSerializer serializer = new XmlSerializer(typeof(List<Account>));

        public Login()
        {
            InitializeComponent();
            ReadInUsers();
        }

        private void ReadInUsers()
        {
            string path = "Users.xml";

            if (File.Exists(path))
            {
                using (FileStream rs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    UserList = serializer.Deserialize(rs) as List<Account>;
                }
            }
        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            List<Pets> p = new List<Pets>();
            if (ValidateAllEntries())
            {
                Account tempAct = UserList.FirstOrDefault(x => x.Username == username.Text);
                if ((tempAct?.Password == password.Password) && (tempAct?.AccountType == "Buyer")) // is that null if not don't do this
                {
                    MainWindow mw = new MainWindow(tempAct, UserList);
                    this.Close();
                    mw.ShowDialog();
                }
                else
                {
                    if ((tempAct?.Password == password.Password) && (tempAct?.AccountType == "Seller"))
                    {
                        SellerWindow sw = new SellerWindow(tempAct, UserList);
                        this.Close();
                        sw.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login credentials", "Login Error");
                    }
                    
                }
            }
        }

        private bool ValidateAllEntries()
        {
            bool loginvalid = string.IsNullOrWhiteSpace(username.Text) ? false : ValidateForLetters(username.Text);
            username.Background = loginvalid ? Brushes.White : Brushes.Coral;
            loginWarning.Visibility = loginvalid ? Visibility.Hidden : Visibility.Visible;

            if (string.IsNullOrWhiteSpace(password.Password)) { return false; }

            return loginvalid;
        }

        private bool ValidateForLetters(string text)
        {
            return text.Where(x => char.IsLetter(x)).Count() == text.Length;
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Create_New_Account(object sender, RoutedEventArgs e)
        {
            AccountMaker NewAccount = new AccountMaker(UserList);
            NewAccount.ShowDialog();
        }
    }
}
