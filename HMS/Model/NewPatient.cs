using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Utils;
namespace HMS.Model
{
    public class NewPatient
    {
        private Utils.OnChangedProperty PPC = new OnChangedProperty();
        private string _strPatientID;
        private string _strPatientName;
        private string _strPatientAge;
        private string _strPatientGender;
        private string _strPatientAddress;
        private string _strPatientPhone;
        private string _strPatientEmail;
        private DateTime _dateTimePatientDOB;
        private string _strFolderLocation;

        public string PatientID
        {
            get
            {
                return _strPatientID;
            }
            set
            {
                _strPatientID = value;
                PPC.NotifyPropertyChanged("PatientID");
            }
        }
        public string PatientName
        {
            get
            {
                return _strPatientName;
            }
            set
            {
                _strPatientName = value;
                PPC.NotifyPropertyChanged("PatientName");
            }
        }
        public string PatientAge
        {
            get
            {
                return _strPatientAge;
            }
            set
            {
                _strPatientAge = value;
                PPC.NotifyPropertyChanged("_strPatientAge");
            }
        }
        public string PatientGender
        {
            get
            {
                return _strPatientGender;
            }
            set
            {
                _strPatientGender = value;
                PPC.NotifyPropertyChanged("PatientGender");
            }
        }
        public string PatientAddress
        {
            get
            {
                return _strPatientAddress;
            }
            set
            {
                _strPatientAddress = value;
                PPC.NotifyPropertyChanged("PatientAddress");
            }
        }
        public string PatientPhone
        {
            get
            {
                return _strPatientPhone;
            }
            set
            {
                _strPatientPhone = value;
                PPC.NotifyPropertyChanged("PatientPhone");
            }
        }
        public string PatientEmail
        {
            get
            {
                return _strPatientEmail;
            }
            set
            {
                _strPatientEmail = value;
                PPC.NotifyPropertyChanged("PatientEmail");
            }
        }
        public DateTime PatientDOB
        {
            get
            {
                return _dateTimePatientDOB;
            }
            set
            {
                _dateTimePatientDOB = value;
                PPC.NotifyPropertyChanged("PatientDOB");
            }
        }
        public string FolderLocation
        {
            get
            {
                return _strFolderLocation;
            }
            set
            {
                _strFolderLocation = value;
                PPC.NotifyPropertyChanged("FolderLocation");
            }
        }
    }
}
