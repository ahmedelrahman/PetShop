using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PetShop
{
    [XmlRoot(ElementName = "UserAccount")]
    public class Account
    {
        [XmlAttribute(DataType = "string")]
        public string Username { get; set; }

        [XmlAttribute(DataType = "string")]
        public string Password { get; set; }

        [XmlAttribute(DataType = "string")]
        public string FirstName { get; set; }

        [XmlAttribute(DataType = "string")]
        public string LastName { get; set; }

        [XmlAttribute(DataType = "string")]
        public string Email { get; set; }

        [XmlAttribute(DataType = "string")]
        public string Address { get; set; }

        [XmlAttribute(DataType = "string")]
        public string PaymentMethod { get; set; }

        [XmlAttribute(DataType = "string")]
        public string AccountType { get; set; }

        [XmlElement(ElementName = "petsToSell")]
        public ObservableCollection<Pets> petsToSell = new ObservableCollection<Pets>();

        public Account() { }

        public Account(string login, string password, string firstname, string lastname, string email, string address, string paymentmethod, string account_type)
        {
            Username = login;
            Password = password;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Address = Address;
            PaymentMethod = paymentmethod;
            AccountType = account_type;
        }
    }
}
