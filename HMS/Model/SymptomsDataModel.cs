using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Utils;
namespace HMS.Model
{
    public class SymptomsDataModel
    {
        private string _Specialization = string.Empty;
        private OnChangedProperty PPC = new OnChangedProperty();
        public string Specialization
        {
            get
            {
                return _Specialization;
            }
            set
            {
                _Specialization = value;
                PPC.NotifyPropertyChanged("Specialization");
            }
        }
    }
}
