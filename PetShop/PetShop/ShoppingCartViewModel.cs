using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace PetShop
{
    public class ShoppingCartViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel Parent { get; set; }
        public ShoppingCartViewModel(MainWindowViewModel parent) { Parent = parent; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void UpdateCartClicked(object obj)
        {
            int totalitems = 0;
            double sumTotal = 0;
            List<object> toDelete = new List<object>();
            List<object> toBuy = new List<object>();

            //ContentControl cc = Parent.Content as ContentControl;
            //ListBox lb = Parent.cContents as ListBox;
            
            //Pets sPet = lb.SelectedItem as Pets;
            
            foreach (object cartObject in Parent.cContents)
            {
                //CollectionViewSource.GetDefaultView(Parent).Refresh();
                if (cartObject is Pets)
                {
                    //ListBox lb = cc.Content as ListBox;
                    Pets pet = cartObject as Pets;
                   // Pets sPet = lb.SelectedItem as Pets;
                    if (validateQuantity(pet.PurchasedAmount, pet.Stock))
                    {
                        CollectionViewSource.GetDefaultView(Parent.cContents).Refresh();
                        
                        sumTotal = double.Parse(pet.Price.Replace("$", "")) * pet.PurchasedAmount;
                        //pet.Stock = pet.Stock + pet.PurchasedAmount;
                        pet.Stock = pet.Stock - pet.PurchasedAmount;
                        if (pet.PurchasedAmount == 0) { toDelete.Add(pet); }
                    }
                }

            }

            foreach (object itemToDelete in toDelete) { Parent.cContents.Remove(itemToDelete); }
            Parent.TotalCost = sumTotal;
            Parent.TotalItems = 0;
        }

        bool validateQuantity(int q, int s)
        {
            bool quantityvalid;
            
            if (q > s)
            {
                quantityvalid = false;
                MessageBox.Show("The quantity you chose for this item exceedes the maximum in stock", "Warning!");
            }
            else
            {
                quantityvalid = true;
            }

            return (quantityvalid);
        }

        public ICommand UpdateCartCommand
        {
            get
            {
                if (_updateCartEvent == null)
                {
                    _updateCartEvent = new DelegateCommand(UpdateCartClicked);
                }

                return _updateCartEvent;
            }
        }
        DelegateCommand _updateCartEvent;

        //double sum;
        //int quantity = 0;
        //public void PlaceOrderClicked(object obj)
        //{
        //    double sumTotal = 0;
        //    //List<object> toDelete = new List<object>();
        //    List<object> toBuy = new List<object>();

        //    //ContentControl cc = Parent.Content as ContentControl;
        //    //ListBox lb = Parent.cContents as ListBox;

        //    //Pets sPet = lb.SelectedItem as Pets;

        //    foreach (object cartObject in Parent.cContents)
        //    {
        //        //CollectionViewSource.GetDefaultView(Parent).Refresh();
        //        if (cartObject is Pets)
        //        {
        //            //ListBox lb = cc.Content as ListBox;
        //            Pets pet = cartObject as Pets;
        //            // Pets sPet = lb.SelectedItem as Pets;
        //            //  if (validateQuantity(pet.PurchasedAmount, pet.Stock))
        //            //  {
        //            //   CollectionViewSource.GetDefaultView(Parent.cContents).Refresh();

        //            sumTotal = double.Parse(pet.Price.Replace("$", "")) * pet.PurchasedAmount;
        //            //pet.Stock = pet.Stock + pet.PurchasedAmount;
        //            pet.Stock = pet.Stock - pet.PurchasedAmount;
        //            toBuy.Add(pet);
        //            sum += sumTotal;
        //            quantity += pet.PurchasedAmount;
        //            //   }
        //        }

        //    }

        //    UserReceipt receipt = new UserReceipt(toBuy, sum, quantity);
        //    receipt.ShowDialog();

        //}

        //public ICommand ConfirmTransactionCommand
        //{
        //    get
        //    {
        //        if (_confirmtransaction == null)
        //        {
        //            _confirmtransaction = new DelegateCommand(PlaceOrderClicked);
        //        }

        //        return _confirmtransaction;
        //    }
        //}
        //DelegateCommand _confirmtransaction;
    }
}
