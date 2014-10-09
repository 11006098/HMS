using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProductMvvm.ViewModels
{
    //Class for the GUI to display and modify products.
    //All product properties the GUI can touch are strings.
    //A single integer property, ProductId, is for database use only.
    //It is assigned by the DB when it creates a new product.  It is used
    //to identify a product and must not be modified by the GUI.
    public class Product
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        //For DB use only!
        private int _productId;
        public int _ProductId { get { return _productId; } }

        private string modelNumber;
        public string ModelNumber
        {
            get { return modelNumber; }
            set { modelNumber = value; OnPropertyChanged(new PropertyChangedEventArgs("ModelNumber"));
                }
        }


        private string modelName;
        public string ModelName
        {
            get { return modelName; }
            set { modelName = value; OnPropertyChanged(new PropertyChangedEventArgs("ModelName")); }
        }

        private string unitCost;
        public string UnitCost
        {
            get { return unitCost; }
            set { unitCost = value; OnPropertyChanged(new PropertyChangedEventArgs("UnitCost")); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(new PropertyChangedEventArgs("Description")); }
        }

        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; OnPropertyChanged(new PropertyChangedEventArgs("CategoryName")); }
        }

        public Product()
        {
        }

        public Product(int productId, string modelNumber, string modelName,
                       string unitCost, string description, string categoryName)
        {
            this._productId = productId;
            ModelNumber = modelNumber;
            ModelName = modelName;
            UnitCost = unitCost;
            Description = description;
            CategoryName = categoryName;
        }

        public void CopyProduct(Product p)
        {
            this._productId = p._ProductId;
            this.ModelNumber = p.ModelNumber;
            this.ModelName = p.ModelName;
            this.UnitCost = p.UnitCost;
            this.CategoryName = p.CategoryName;
            this.Description = p.Description;
        }

        //Creating a new product in the DB assigns the ProductId
        //Update the ProductId from the value in the corresponding SqlProduct
        public void ProductAdded2DB(SqlProduct sqlProduct)
        {
            this._productId = sqlProduct.ProductId;
        }

    } //class Product



    //Communiction to/from SQL uses this class for product
    //It has a decimal, not string, definition for UnitCost
    //Consversion routines SqlProduct <--> Product provided
    public class SqlProduct
    {
        public int ProductId { get; set; }
        public string ModelNumber {get; set;}
        public string ModelName {get; set;}
        public decimal UnitCost {get; set;}
        public string Description {get; set;}
        public string CategoryName {get; set;}

        public SqlProduct() { }

        public SqlProduct(int productId, string modelNumber, string modelName,
                       decimal unitCost, string description, string categoryName)
        {
            ProductId = productId;
            ModelNumber = modelNumber;
            ModelName = modelName;
            UnitCost = unitCost;
            Description = description;
            CategoryName = categoryName;
        }

        public SqlProduct(Product p)
        {
            ProductId = p._ProductId;
            ModelNumber = p.ModelNumber;
            ModelName = p.ModelName;
            UnitCost = Convert.ToDecimal(p.UnitCost);
            Description = p.Description;
            CategoryName = p.CategoryName;
        }

        public Product SqlProduct2Product()
        {
            string unitCost = UnitCost.ToString();
            return new Product(ProductId, ModelNumber, ModelName, unitCost, Description, CategoryName);
        } //SqlProduct2Product()
    }

}
