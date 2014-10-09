using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Utils;

namespace HMS.Model
{
    public class SymptomsDataModel2
    {
        private string _name ;
        private string _contact;
        private string _date ;
        private string _email;
        private string _time;
        private string _doctorID;
        private OnChangedProperty PPC = new OnChangedProperty();
        public string DoctorID
        {
            get
            {
                return _doctorID;
            }
            set
            {
                _doctorID = value;
                PPC.NotifyPropertyChanged("DoctorID");
            }

        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                PPC.NotifyPropertyChanged("Name");
            }

        }
        public string Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
                PPC.NotifyPropertyChanged("Contact");
            }

        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                PPC.NotifyPropertyChanged("Email");
            }

        }
        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                PPC.NotifyPropertyChanged("Date");
            }

        }
        public string Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                PPC.NotifyPropertyChanged("Time");
            }

        }
    }
}
