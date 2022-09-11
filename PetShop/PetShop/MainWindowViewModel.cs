using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public TabItem SelectedTab { get; set; }

        private ObservableCollection<object> _cContents = new ObservableCollection<object>();
        public ObservableCollection<object> cContents
        {
            get { return _cContents; }
            set
            {
                _cContents = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CartContents"));
            }
        }

        private double _totalCost = 0;
        public double TotalCost
        {
            get { return _totalCost; }
            set
            {
                _totalCost = value;
                TotalCostDisplay = "$" + string.Format("{0:N2}", _totalCost);
                PropertyChanged(this, new PropertyChangedEventArgs("TotalCost"));
            }
        }

        private string totalCostdisplay;
        public string TotalCostDisplay
        {
            get { return totalCostdisplay; }
            set
            {
                totalCostdisplay = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TotalCostDisplay"));
            }
        }

        private string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Quantity"));
            }
        }

        private int _totalitems = 0;
        public int TotalItems
        {
            get { return _totalitems; }
            set
            {
                _totalitems = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TotalItems"));
            }
        }
        Account u = new Account();
        List<Account> l = new List<Account>();

        public MainWindowViewModel(Account user, List<Account> UsersList)
        {
            u = user;
            l = UsersList;
        }

        private void AddToCartClicked(object obj)
        {
            ContentControl cc = SelectedTab.Content as ContentControl;
            ListBox lb = cc.Content as ListBox;
            if (Quantity != null)
            {
                int purchasedAmount = int.Parse(Quantity);

                SeaPet sPet = lb.SelectedItem as SeaPet;
                LandPet lPet = lb.SelectedItem as LandPet;
                BirdCages bc = lb.SelectedItem as BirdCages;
                CatBeds cb = lb.SelectedItem as CatBeds;
                DogBeds db = lb.SelectedItem as DogBeds;
                FishBowls fb = lb.SelectedItem as FishBowls;
                FishFood ff = lb.SelectedItem as FishFood;
                DogFood df = lb.SelectedItem as DogFood;
                CatFood cf = lb.SelectedItem as CatFood;
                BirdFood bf = lb.SelectedItem as BirdFood;
                DogClothes dc = lb.SelectedItem as DogClothes;
                CatClothes cclothes = lb.SelectedItem as CatClothes;

                if (cclothes != null)
                {
                    if (validateQuantity(purchasedAmount, cclothes.Stock) == true)
                    {
                        CollectionViewSource.GetDefaultView(lb.ItemsSource).Refresh();

                        TotalItems += purchasedAmount;

                        if (SelectedTab.Header.ToString() == "Cat Clothes")
                        {
                            CatClothes selectedPet = lb.SelectedItem as CatClothes;
                            selectedPet.Stock = selectedPet.Stock - purchasedAmount;
                            selectedPet.PurchasedAmount += purchasedAmount;

                            bool same = false;
                            foreach (object p in cContents)
                            {
                                if (p as CatClothes == selectedPet)
                                {
                                    same = true;
                                    break;
                                }
                            }
                            if (same == false)
                            {
                                cContents.Add(selectedPet as object);
                            }
                            TotalCost += double.Parse(selectedPet.Price.Replace("$", "")) * purchasedAmount;
                        }
                    }
                }

                if (dc != null)
                {
                    if (validateQuantity(purchasedAmount, dc.Stock) == true)
                    {
                        CollectionViewSource.GetDefaultView(lb.ItemsSource).Refresh();

                        TotalItems += purchasedAmount;

                        if (SelectedTab.Header.ToString() == "Dog Clothes")
                        {
                            DogClothes selectedPet = lb.SelectedItem as DogClothes;
                            selectedPet.Stock = selectedPet.Stock - purchasedAmount;
                            selectedPet.PurchasedAmount += purchasedAmount;

                            bool same = false;
                            foreach (object p in cContents)
                            {
                                if (p as DogClothes == selectedPet)
                                {
                                    same = true;
                                    break;
                                }
                            }
                            if (same == false)
                            {
                                cContents.Add(selectedPet as object);
                            }
                            TotalCost += double.Parse(selectedPet.Price.Replace("$", "")) * purchasedAmount;
                        }
                    }
                }

                if (bf != null)
                {
                    if (validateQuantity(purchasedAmount, bf.Stock) == true)
                    {
                        CollectionViewSource.GetDefaultView(lb.ItemsSource).Refresh();

                        TotalItems += purchasedAmount;

                        if (SelectedTab.Header.ToString() == "Bird Food")
                        {
                            BirdFood selectedPet = lb.SelectedItem as BirdFood;
                            selectedPet.Stock = selectedPet.Stock - purchasedAmount;
                            selectedPet.PurchasedAmount += purchasedAmount;

                            bool same = false;
                            foreach (object p in cContents)
                            {
                                if (p as BirdFood == selectedPet)
                                {
                                    same = true;
                                    break;
                                }
                            }
                            if (same == false)
                            {
                                cContents.Add(selectedPet as object);
                            }
                            TotalCost += double.Parse(selectedPet.Price.Replace("$", "")) * purchasedAmount;
                        }
                    }
                }

                if (cf != null)
                {
                    if (validateQuantity(purchasedAmount, cf.Stock) == true)
                    {
                        CollectionViewSource.GetDefaultView(lb.ItemsSource).Refresh();

                        TotalItems += purchasedAmount;

                        if (SelectedTab.Header.ToString() == "Cat Food")
                        {
                            CatFood selectedPet = lb.SelectedItem as CatFood;
                            selectedPet.Stock = selectedPet.Stock - purchasedAmount;
                            selectedPet.PurchasedAmount += purchasedAmount;

                            bool same = false;
                            foreach (object p in cContents)
                            {
                                if (p as CatFood == selectedPet)
                                {
                                    same = true;
                                    break;
                                }
                            }
                            if (same == false)
                            {
                                cContents.Add(selectedPet as object);
                            }
                            TotalCost += double.Parse(selectedPet.Price.Replace("$", "")) * purchasedAmount;
                        }
                    }
                }

                if (df != null)
                {
                    if (validateQuantity(purchasedAmount, df.Stock) == true)
                    {
                        CollectionViewSource.GetDefaultView(lb.ItemsSource).Refresh();

                        TotalItems += purchasedAmount;

                        if (SelectedTab.Header.ToString() == "Dog Food")
                        {
                            DogFood selectedPet = lb.SelectedItem as DogFood;
                            selectedPet.Stock = selectedPet.Stock - purchasedAmount;
                            selectedPet.PurchasedAmount += purchasedAmount;

                            bool same = false;
                            foreach (object p in cContents)
                            {
                                if (p as DogFood == selectedPet)
                                {
                                    same = true;
                                    break;
                                }
                            }
                            if (same == false)
                            {
                                cContents.Add(selectedPet as object);
                            }
                            TotalCost += double.Parse(selectedPet.Price.Replace("$", "")) * purchasedAmount;
                        }
                    }
                }

                if (ff != null)
                {
                    if (validateQuantity(purchasedAmount, ff.Stock) == true)
                    {
                        CollectionViewSource.GetDefaultView(lb.ItemsSource).Refresh();

                        TotalItems += purchasedAmount;

                        if (SelectedTab.Header.ToString() == "Fish Food")
                        {
                            FishFood selectedPet = lb.SelectedItem as FishFood;
                            selectedPet.Stock = selectedPet.Stock - purchasedAmount;
                            selectedPet.PurchasedAmount += purchasedAmount;

                            bool same = false;
                            foreach (object p in cContents)
                            {
                                if (p as FishFood == selectedPet)
                                {
                                    same = true;
                                    break;
                                }
                            }
                            if (same == false)
                            {
                                cContents.Add(selectedPet as object);
                            }
                            TotalCost += double.Parse(selectedPet.Price.Replace("$", "")) * purchasedAmount;
                        }
                    }
                }

                if (fb != null)
                {
                    if (validateQuantity(purchasedAmount, fb.Stock) == true)
                    {
                        CollectionViewSource.GetDefaultView(lb.ItemsSource).Refresh();

                        TotalItems += purchasedAmount;

                        if (SelectedTab.Header.ToString() == "Fish Bowls")
                        {
                            FishBowls selectedPet = lb.SelectedItem as FishBowls;
                            selectedPet.Stock = selectedPet.Stock - purchasedAmount;
                            selectedPet.PurchasedAmount += purchasedAmount;

                            bool same = false;
                            foreach (object p in cContents)
                            {
                                if (p as FishBowls == selectedPet)
                                {
                                    same = true;
                                    break;
                                }
                            }
                            if (same == false)
                            {
                                cContents.Add(selectedPet as object);
                            }
                            TotalCost += double.Parse(selectedPet.Price.Replace("$", "")) * purchasedAmount;
                        }
                    }
                }

                if (cb != null)
                {
                    if (validateQuantity(purchasedAmount, cb.Stock) == true)
                    {
                        CollectionViewSource.GetDefaultView(lb.ItemsSource).Refresh();

                        TotalItems += purchasedAmount;

                        if (SelectedTab.Header.ToString() == "Cat Beds")
                        {
                            CatBeds selectedPet = lb.SelectedItem as CatBeds;
                            selectedPet.Stock = selectedPet.Stock - purchasedAmount;
                            selectedPet.PurchasedAmount += purchasedAmount;

                            bool same = false;
                            foreach (object p in cContents)
                            {
                                if (p as CatBeds == selectedPet)
                                {
                                    same = true;
                                    break;
                                }
                            }
                            if (same == false)
                            {
                                cContents.Add(selectedPet as object);
                            }
                            TotalCost += double.Parse(selectedPet.Price.Replace("$", "")) * purchasedAmount;
                        }
                    }
                }

                if (bc != null)
                {
                    if (validateQuantity(purchasedAmount, bc.Stock) == true)
                    {
                        CollectionViewSource.GetDefaultView(lb.ItemsSource).Refresh();

                        TotalItems += purchasedAmount;

                        if (SelectedTab.Header.ToString() == "Bird Cages")
                        {
                            BirdCages selectedPet = lb.SelectedItem as BirdCages;
                            selectedPet.Stock = selectedPet.Stock - purchasedAmount;
                            selectedPet.PurchasedAmount += purchasedAmount;

                            bool same = false;
                            foreach (object p in cContents)
                            {
                                if (p as BirdCages == selectedPet)
                                {
                                    same = true;
                                    break;
                                }
                            }
                            if (same == false)
                            {
                                cContents.Add(selectedPet as object);
                            }
                            TotalCost += double.Parse(selectedPet.Price.Replace("$", "")) * purchasedAmount;
                        }
                    }
                }

                if (sPet != null)
                {
                    if (validateQuantity(purchasedAmount, sPet.Stock) == true)
                    {
                        CollectionViewSource.GetDefaultView(lb.ItemsSource).Refresh();

                        TotalItems += purchasedAmount;

                        if (SelectedTab.Header.ToString() == "Sea Pets")
                        {
                            SeaPet selectedPet = lb.SelectedItem as SeaPet;
                            selectedPet.Stock = selectedPet.Stock - purchasedAmount;
                            selectedPet.PurchasedAmount += purchasedAmount;

                            bool same = false;
                            foreach (object p in cContents)
                            {
                                if (p as SeaPet == selectedPet)
                                {
                                    same = true;
                                    break;
                                }
                            }
                            if (same == false)
                            {
                                cContents.Add(selectedPet as object);
                            }
                            TotalCost += double.Parse(selectedPet.Price.Replace("$", "")) * purchasedAmount;
                        }
                    }
                }

                if (lPet != null)
                {
                    if (validateQuantity(purchasedAmount, lPet.Stock) == true)
                    {
                        CollectionViewSource.GetDefaultView(lb.ItemsSource).Refresh();

                        TotalItems += purchasedAmount;

                        if (SelectedTab.Header.ToString() == "Land Pets")
                        {
                            LandPet selectedPet = lb.SelectedItem as LandPet;
                            selectedPet.Stock = selectedPet.Stock - purchasedAmount;
                            selectedPet.PurchasedAmount += purchasedAmount;

                            bool same = false;
                            foreach (object p in cContents)
                            {
                                if (p as LandPet == selectedPet)
                                {
                                    same = true;
                                    break;
                                }
                            }
                            if (same == false)
                            {
                                cContents.Add(selectedPet as object);
                            }
                            TotalCost += double.Parse(selectedPet.Price.Replace("$", "")) * purchasedAmount;
                        }
                    }
                }
            }
        }

        bool validateQuantity(int q, int s)
        {
            bool quantityvalid;

            if(s <= 0 || (s-q)<0)
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

        public ICommand AddToCartCommand
        {
            get
            {
                if (_addToCartEvent == null)
                {
                    _addToCartEvent = new DelegateCommand(AddToCartClicked);
                }

                return _addToCartEvent;
            }
        }
        DelegateCommand _addToCartEvent;

        private void OpenCartClicked(object obj)
        {
            ShoppingCartViewModel shoppingCartVM = new ShoppingCartViewModel(this);
            shopCart cart = new shopCart();
            cart.DataContext = shoppingCartVM;
            cart.Show();
        }

        public ICommand OpenCartCommand
        {
            get
            {
                if (_openCartEvent == null)
                {
                    _openCartEvent = new DelegateCommand(OpenCartClicked);
                }

                return _openCartEvent;
            }
        }

        public ContentControl Content { get; internal set; }

        DelegateCommand _openCartEvent;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };


        double sum;
        int quantity = 0;
        public void PlaceOrderClicked(object obj)
        {
            double sumTotal = 0;
            List<object> toBuy = new List<object>();

            foreach (object cartObject in cContents)
            {
                
                if (cartObject is SeaPet)
                {
                    SeaPet pet = cartObject as SeaPet;
                    
                    sumTotal = double.Parse(pet.Price.Replace("$", "")) * pet.PurchasedAmount;
                    
                    pet.Stock = pet.Stock - pet.PurchasedAmount;
                    toBuy.Add(pet);
                    sum += sumTotal;
                    quantity += pet.PurchasedAmount;

                }

            }

            UserReceipt receipt = new UserReceipt(toBuy, sum, quantity,u,l );
            receipt.ShowDialog();

        }

        public ICommand ConfirmTransactionCommand
        {
            get
            {
                if (_confirmtransaction == null)
                {
                    _confirmtransaction = new DelegateCommand(PlaceOrderClicked);
                }

                return _confirmtransaction;
            }
        }
        DelegateCommand _confirmtransaction;
    }
}

