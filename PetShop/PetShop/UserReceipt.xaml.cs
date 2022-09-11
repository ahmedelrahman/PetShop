using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace PetShop
{
    /// <summary>
    /// Interaction logic for UserReceipt.xaml
    /// </summary>
    public partial class UserReceipt : Window
    {
        //XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Student>));

        string localSaveLocation = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\receipt.txt";

        double t_sum;
        int q;
        Account User = new Account();
        List<Account> List = new List<Account>();
        public UserReceipt(List<object> toBuy, double sum, int quantity, Account user, List<Account> list)
        {
            InitializeComponent();
            List<Pets> petlist = new List<Pets>();
            t_sum = sum;
            User = user;
            List = list;

            int count = 0;
            q = quantity;

            foreach (object pet in toBuy)
            {
                Pets pet1 = pet as Pets;
                if (count == 0)
                {
                    petlist.Add(pet as Pets);
                    pet1name.Content = pet1.Name;
                    pet1description.Content = pet1.Description + ", " + pet1.PurchasedAmount + " items";
                }
                if (count == 1)
                {
                    petlist.Add(pet as Pets);
                    pet2name.Content = pet1.Name;
                    pet2description.Content = pet1.Description + ", " + pet1.PurchasedAmount + " items";
                }
                if (count == 2)
                {
                    petlist.Add(pet as Pets);
                    pet3name.Content = pet1.Name;
                    pet3description.Content = pet1.Description + ", " + pet1.PurchasedAmount + " items";
                }
                if (count == 3)
                {
                    petlist.Add(pet as Pets);
                    pet4name.Content = pet1.Name;
                    pet4description.Content = pet1.Description + ", " + pet1.PurchasedAmount + " items";
                }
                petlist.Add(pet as Pets);
                count++;
            }

            TotalSum.Content = "Your total sum is: $" + sum;
            
            //ListOfPets.ItemsSource = toBuy;
            
        }

        private void SaveReceipt(object sender, RoutedEventArgs e)
        {
            
            string saveType = (sender as System.Windows.Controls.MenuItem).CommandParameter.ToString();

            if (saveType == "Save")
            {
                string fileText = "Your total sum is $" + t_sum;

                SaveFileDialog dialog = new SaveFileDialog()
                {
                    Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
                };

                //if (dialog.ShowDialog())
                // {
                File.WriteAllText(localSaveLocation, fileText);
                //}
            }

            else if (saveType == "SaveAs")
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "TXT Files(*.txt)|*.txt";
                saveDialog.InitialDirectory = "@C";

                string fileText = "Date of Purchase: "+ DateTime.Now.ToString() +",  Your total sum is $" + t_sum + ",  You have bought "+ q;

                saveDialog.ShowDialog();

                localSaveLocation = saveDialog.FileName;
                File.WriteAllText(localSaveLocation, fileText);

            }

            //MessageBox.Show("All students have been written to file", "Success");
        }

        private void email(object sender, RoutedEventArgs e)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com"); //using the gmail server
            client.Port = 587; // Set up port
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Timeout = 10000; // in ms Timeout in 10 secs
            client.Credentials = new System.Net.NetworkCredential(User.Username, User.Password);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("suckaduck32@gmail.com");
            Console.WriteLine(User.Email);
            mail.To.Add(User.Email);
            mail.Subject = "Verify Your New Account";
            mail.Body = $"Welcome {User.Username} to the new application, you must verify your account by clicking the link!";
            mail.BodyEncoding = Encoding.UTF8;
        }
    }
}
