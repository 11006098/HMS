using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmFoundation.Wpf;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;



namespace ProductMvvm.ViewModels
{
    public class ProductDisplayModel : INotifyPropertyChanged
    {
        private bool isSelected = false;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        //data checks and status indicators done in another class
        private readonly ProductDisplayModelStatus stat = new ProductDisplayModelStatus();
        public ProductDisplayModelStatus Stat { get { return stat; } }

        private Product displayedProduct = new Product();
        public Product DisplayedProduct
        {
            get { return displayedProduct; }
            set { displayedProduct = value; OnPropertyChanged(new PropertyChangedEventArgs("DisplayedProduct")); }
        }


        private RelayCommand getProductsCommand;
        public ICommand GetProductsCommand
        {
            get { return getProductsCommand ?? (getProductsCommand = new RelayCommand(() => GetProducts())); }
        }

        private void GetProducts()
        {
            isSelected = false;
            stat.NoError();
            DisplayedProduct = new Product();
            App.Messenger.NotifyColleagues("GetProducts");
        }


        private RelayCommand clearCommand;
        public ICommand ClearCommand
        {
            get { return clearCommand ?? (clearCommand = new RelayCommand(() => ClearProductDisplay()/*, ()=>isSelected*/)); }
        }

        private void ClearProductDisplay()
        {
            isSelected = false;
            stat.NoError();
            DisplayedProduct = new Product();
            App.Messenger.NotifyColleagues("ProductCleared");
        } //ClearProductDisplay()


        private RelayCommand updateCommand;
        public ICommand UpdateCommand
        {
            get { return updateCommand ?? (updateCommand = new RelayCommand(() => UpdateProduct(), ()=>isSelected)); }
        }

        private void UpdateProduct()
        {
            if (!stat.ChkProductForUpdate(DisplayedProduct)) return;
                if(!App.StoreDB.UpdateProduct(DisplayedProduct))
                {
                    stat.Status = App.StoreDB.errorMessage;
                    return;
                }
                App.Messenger.NotifyColleagues("UpdateProduct", DisplayedProduct);
        } //UpdateProduct()


        private RelayCommand deleteCommand;
        public ICommand DeleteCommand
        {
            get { return deleteCommand ?? (deleteCommand = new RelayCommand(() => DeleteProduct(), () => isSelected)); }
        }


        private void DeleteProduct()
        {
            if (!App.StoreDB.DeleteProduct(DisplayedProduct._ProductId))
            {
                stat.Status = App.StoreDB.errorMessage;
                return;
            }
            isSelected = false;
            App.Messenger.NotifyColleagues("DeleteProduct");
        } //DeleteProduct


        private RelayCommand addCommand;
        public ICommand AddCommand
        {
            get { return addCommand ?? (addCommand = new RelayCommand(() => AddProduct(), () => !isSelected)); }
        }


        private void AddProduct()
        {
            if (!stat.ChkProductForAdd(DisplayedProduct)) return;
            if (!App.StoreDB.AddProduct(DisplayedProduct))
            {
                stat.Status = App.StoreDB.errorMessage;
                return;
            }
            App.Messenger.NotifyColleagues("AddProduct", DisplayedProduct);
        } //AddProduct()


        public ProductDisplayModel()
        {
            Messenger messenger = App.Messenger;
            messenger.Register("ProductSelectionChanged", (Action<Product>)(param => ProcessProduct(param)));
            messenger.Register("SetStatus", (Action<String>)(param => stat.Status = param));
        } //ctor

        public void ProcessProduct(Product p)
        {
            if (p == null) { /*DisplayedProduct = null;*/  isSelected = false;  return; }
            Product temp = new Product();
            temp.CopyProduct(p);
            DisplayedProduct = temp;
            isSelected = true;
            stat.NoError();
        } // ProcessProduct()
    }
}
