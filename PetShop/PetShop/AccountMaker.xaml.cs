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
    /// Interaction logic for AccountMaker.xaml
    /// </summary>
    public partial class AccountMaker : Window
    {
        public List<Account> Users { get; set; }
        XmlSerializer serializer = new XmlSerializer(typeof(List<Account>));
        public bool IsEdit { get; set; }
        public Account EditingUser { get; set; }

        public AccountMaker(List<Account> users, bool isEdit = false)
        {
            InitializeComponent();
            Users = users;
            IsEdit = isEdit;
        }

        private void add_user(object sender, RoutedEventArgs e)
        {
            if (ValidateAllEntries())
            {
                if (IsEdit)
                {
                    Account userToModify = Users.FirstOrDefault(x => x == EditingUser);
                    userToModify.Username = username.Text;
                    userToModify.Password = password.Password;
                    userToModify.FirstName = firstname.Text;
                    userToModify.LastName = lastname.Text;
                    userToModify.Email = email.Text + "@" + domain.Text;
                    userToModify.Address = address.Text;
                    userToModify.PaymentMethod = paymentmethod.SelectedItem.ToString();
                   // userToModify.AccountType = 

                    string path = "Users.xml";
                    if (File.Exists(path))
                    {
                        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                        {
                            serializer.Serialize(fs, Users);
                        }
                    }

                    MessageBox.Show("Account has been Updated", "Success!");
                    this.Close();
                }
                else
                {
                    string type_of_account = "";
                    if (BuyerRadioButton.IsChecked == true)
                    {
                        type_of_account = "Buyer";
                    }
                    if (SellerRadioButton.IsChecked == true)
                    {
                        type_of_account = "Seller";
                    }
                    Account act = new Account(username.Text, password.Password, firstname.Text, lastname.Text, email.Text + "@" + domain.Text, address.Text, paymentmethod.SelectedItem.ToString(), type_of_account);
                    Users.Add(act);

                    string path = "Users.xml";
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                    {
                        serializer.Serialize(fs, Users);
                    }
                    MessageBox.Show("Account has been created", "Success!");
                    this.Close();
                }
            }
        }

        private bool ValidateAllEntries()
        {
            bool FirstNamevalid = string.IsNullOrWhiteSpace(firstname.Text) ? false : ValidateForLetters(firstname.Text);
            firstname.Background = FirstNamevalid ? Brushes.White : Brushes.Coral;
            FirstNameWarning.Visibility = FirstNamevalid ? Visibility.Hidden : Visibility.Visible;

            if (FirstNamevalid == false)
            {
                MessageBox.Show("Your First Name can not include any space or any special characters", "Warning!");
            }

            bool LastNamevalid = string.IsNullOrWhiteSpace(lastname.Text) ? false : ValidateForLetters(lastname.Text);
            lastname.Background = LastNamevalid ? Brushes.White : Brushes.Coral;
            LastNameWarning.Visibility = LastNamevalid ? Visibility.Hidden : Visibility.Visible;

            if (LastNamevalid == false)
            {
                MessageBox.Show("Your Last Name can not include any space or any special characters", "Warning!");
            }

            bool UserNamevalid = string.IsNullOrWhiteSpace(username.Text) ? false : ValidateForLetters(username.Text);
            username.Background = UserNamevalid ? Brushes.White : Brushes.Coral;
            UsernameWarning.Visibility = UserNamevalid ? Visibility.Hidden : Visibility.Visible;

            if (UserNamevalid == false)
            {
                MessageBox.Show("Your Username can not include any space or any special characters", "Warning!");
            }

            // validates address
            bool homeAddressvalid;

            if (string.IsNullOrWhiteSpace(address.Text))
            {
                homeAddressvalid = false;
                address.Background = Brushes.Coral;
                AddressWarning.Visibility = Visibility.Visible;
            }
            else
            {
                homeAddressvalid = true;
                address.Background = Brushes.White;
                AddressWarning.Visibility = Visibility.Hidden;
            }

            if (homeAddressvalid == false)
            {
                MessageBox.Show("Your Address can not include any space or any special characters", "Warning!");
            }

            // validates email
            bool emailValid = true;

            if (string.IsNullOrWhiteSpace(email.Text) != true && string.IsNullOrWhiteSpace(domain.Text) != true)
            {
                if (domain.Text.Contains(".") && email.Text.Contains(".") == false)
                {
                    emailValid = true;
                    domain.Background = Brushes.White;
                    email.Background = Brushes.White;
                }

                else
                {

                    if (domain.Text.Contains(".") == false && email.Text.Contains(".") == true)
                    {
                        emailValid = false;
                        domain.Background = Brushes.Coral;
                        email.Background = Brushes.Coral;
                        MessageBox.Show("your domain must contain a dot symbol and the first half of your email must not contain a dot symbol", "Error Message");
                        //HomeAddressWarning.Visibility = Visibility.Visible;
                    }

                    if (domain.Text.Contains(".") == false)
                    {
                        emailValid = false;
                        domain.Background = Brushes.Coral;
                        MessageBox.Show("your domain must contain a dot symbol", "Error Message");
                        //HomeAddressWarning.Visibility = Visibility.Visible;
                    }

                    if (email.Text.Contains(".") == true)
                    {
                        emailValid = false;
                        email.Background = Brushes.Coral;
                        MessageBox.Show("the first half of your email must not contain a dot symbol", "Error Message");
                    }
                }
            }
            else
            {
                emailValid = false;
                domain.Background = Brushes.Coral;
                email.Background = Brushes.Coral;
                MessageBox.Show("Please enter your email", "Error Message");
            }

            // validates radio button
            bool AccountTypeValid;

            if (BuyerRadioButton.IsChecked == true || SellerRadioButton.IsChecked == true)
            {
                AccountTypeValid = true;
                RadioButtonParent.Background = Brushes.White;
                AccountTypeWarning.Visibility = Visibility.Hidden;
            }
            else
            {
                AccountTypeValid = false;
                RadioButtonParent.Background = Brushes.Coral;
                AccountTypeWarning.Visibility = Visibility.Visible;
            }

            //validates combo box
            bool comboBoxValid;

            if (paymentmethod.SelectedItem != null)
            {
                comboBoxValid = true;
                paymentmethod.Background = Brushes.White;
                PaymentMethodWarning.Visibility = Visibility.Hidden;
            }
            else
            {
                comboBoxValid = false;
                paymentmethod.Background = Brushes.Coral;
                PaymentMethodWarning.Visibility = Visibility.Visible;
            }

            if (string.IsNullOrWhiteSpace(password.Password)) { return false; }

            return (FirstNamevalid && UserNamevalid && LastNamevalid && homeAddressvalid && emailValid && AccountTypeValid && comboBoxValid);
        }

        // function validates for letters
        private bool ValidateForLetters(string text)
        {
            return text.Where(x => char.IsLetter(x)).Count() == text.Length;
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
