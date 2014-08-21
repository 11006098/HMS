using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;


namespace ProductMvvm.ViewModels
{
    //Product Error detection, error display and status msg
    //Note, a Delete may be performed without checking any Productt fields
    public class ProductDisplayModelStatus : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        //Error status msg and field Brushes to indicate product field errors
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(new PropertyChangedEventArgs("Status")); }
        }
        private static SolidColorBrush errorBrush = new SolidColorBrush(Colors.Red);
        private static SolidColorBrush okBrush = new SolidColorBrush(Colors.Black);

        private SolidColorBrush modelNumberBrush = okBrush;
        public SolidColorBrush ModelNumberBrush
        {
            get { return modelNumberBrush; }
            set { modelNumberBrush = value; OnPropertyChanged(new PropertyChangedEventArgs("ModelNumberBrush")); }
        }

        private SolidColorBrush modelNameBrush = okBrush;
        public SolidColorBrush ModelNameBrush
        {
            get { return modelNameBrush; }
            set { modelNameBrush = value; OnPropertyChanged(new PropertyChangedEventArgs("ModelNameBrush")); }
        }

        private SolidColorBrush categoryNameBrush = okBrush;
        public SolidColorBrush CategoryNameBrush
        {
            get { return categoryNameBrush; }
            set { categoryNameBrush = value; OnPropertyChanged(new PropertyChangedEventArgs("CategoryNameBrush")); }
        }

        private SolidColorBrush unitCostBrush = okBrush;
        public SolidColorBrush UnitCostBrush
        {
            get { return unitCostBrush; }
            set { unitCostBrush = value; OnPropertyChanged(new PropertyChangedEventArgs("UnitCostBrush")); }
        }


        //set error field brushes to OKBrush and status msg to OK
        public void NoError()
        {
            ModelNumberBrush = ModelNameBrush = CategoryNameBrush = UnitCostBrush = okBrush;
            Status = "OK";
        } //NoError()


        public ProductDisplayModelStatus()
        {
            NoError();
        } //ctor


        //verify the Product's unitcost is a decimal number > 0
        private bool ChkUnitCost(string costString)
        {
            if (String.IsNullOrEmpty(costString))
                return false;
            else
            {
                decimal unitCost;
                try
                {
                    unitCost = Decimal.Parse(costString);
                }
                catch
                {
                    return false;
                }
                if (unitCost < 0)
                    return false;
                else return true;
            }
        } //ChkUnitCost()


        //check all product fields for validity
        public bool ChkProductForAdd(Product p)
        {
            int errCnt = 0;
            if (String.IsNullOrEmpty(p.ModelNumber))
            { errCnt++; ModelNumberBrush = errorBrush; }
            else ModelNumberBrush = okBrush;
            if (String.IsNullOrEmpty(p.ModelName))
            { errCnt++; ModelNameBrush = errorBrush; }
            else ModelNameBrush = okBrush;
            if (String.IsNullOrEmpty(p.CategoryName))
            { errCnt++; CategoryNameBrush = errorBrush; }
            else CategoryNameBrush = okBrush;

            if (!ChkUnitCost(p.UnitCost))
            { errCnt++; UnitCostBrush = errorBrush; }

            if (errCnt == 0) { Status = "OK"; return true; }
            else { Status = "ADD, missing or invalid fields."; return false; }
        } //ChkProductForAdd()


        //check all product fields for validity
        public bool ChkProductForUpdate(Product p)
        {
            int errCnt = 0;
            if (String.IsNullOrEmpty(p.ModelNumber))
            { errCnt++; ModelNumberBrush = errorBrush; }
            else ModelNumberBrush = okBrush;
            if (String.IsNullOrEmpty(p.ModelName))
            { errCnt++; ModelNameBrush = errorBrush; }
            else ModelNameBrush = okBrush;
            if (String.IsNullOrEmpty(p.CategoryName))
            { errCnt++; CategoryNameBrush = errorBrush; }
            else CategoryNameBrush = okBrush;

            if (!ChkUnitCost(p.UnitCost))
            { errCnt++; UnitCostBrush = errorBrush; }
            else UnitCostBrush = okBrush;

            if (errCnt == 0) { Status = "OK"; return true; }
            else { Status = "Update, missing or invalid fields."; return false; }
        } //ChkProductForUpdate()

    } //class ProductDisplayModelStatus
}  //NS: ProductMvvm.ViewModels
