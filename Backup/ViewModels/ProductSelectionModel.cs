using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MvvmFoundation.Wpf;

namespace ProductMvvm.ViewModels
{
    public class ProductSelectionModel : INotifyPropertyChanged
    {

        public ProductSelectionModel()
        {
            dataItems = new MyObservableCollection<Product>();
            DataItems = App.StoreDB.GetProducts();
            listBoxCommand = new RelayCommand(() => SelectionHasChanged());
            App.Messenger.Register("ProductCleared", (Action)(() => SelectedProduct=null));
            App.Messenger.Register("GetProducts", (Action)(() => GetProducts()));
            App.Messenger.Register("UpdateProduct",  (Action<Product>)(param => UpdateProduct(param)));
            App.Messenger.Register("DeleteProduct", (Action)(() => DeleteProduct()));
            App.Messenger.Register("AddProduct", (Action<Product>)(param => AddProduct(param)));
        }


        private void GetProducts()
        {
            DataItems = App.StoreDB.GetProducts();
            if (App.StoreDB.hasError)
                App.Messenger.NotifyColleagues("SetStatus", App.StoreDB.errorMessage);
        }


        private void AddProduct(Product p)
        {
            dataItems.Add(p);
        }


        private void UpdateProduct(Product p)
        {
            int index = dataItems.IndexOf(selectedProduct);
            dataItems.ReplaceItem(index, p);
            SelectedProduct = p;
        }


        private void DeleteProduct()
        {
            dataItems.Remove(selectedProduct);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private MyObservableCollection<Product> dataItems;
        public MyObservableCollection<Product> DataItems
        {
            get { return dataItems; }
            //If dataItems replaced by new collection, WPF must be told
            set { dataItems = value; OnPropertyChanged(new PropertyChangedEventArgs("DataItems")); }
        }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(new PropertyChangedEventArgs("SelectedProduct")); }
        }

        private RelayCommand listBoxCommand;
        public ICommand ListBoxCommand
        {
            get { return listBoxCommand; }
        }

        private void SelectionHasChanged()
        {
            Messenger messenger = App.Messenger;
            messenger.NotifyColleagues("ProductSelectionChanged", selectedProduct);
        }
    }//class ProductSelectionModel



    public class MyObservableCollection<Product> : ObservableCollection<Product>
    {
        public void UpdateCollection()
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Reset));
        }


        public void ReplaceItem(int index, Product item)
        {
             base.SetItem(index, item);      
        }

    } // class MyObservableCollection
}
