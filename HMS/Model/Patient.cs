using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Utils;
namespace HMS.Model
{
    public class Patient
    {
        private string _strID;
        private string _strPatientName;
        private string _addressPatient;
        private string _contactPatient;
        private DateTime _lastVist;
        private string _strDocName;
        private DateTime _newAppointment;
        private OnChangedProperty PPC = new OnChangedProperty();
        
        
        public Patient() { }
        public Patient(string id, string patientName, string addressPatient, string contactPatient, DateTime lastVisit,
            string docName, DateTime newAppointment)
        {
            ID = id;
            PatientName = patientName;
            AddressPatient = addressPatient;
            ContactPatient = contactPatient;
            LastVisit = lastVisit;
            DoctorName = docName;
            NewAppointment = newAppointment;
        }
        
        public string ID
        {
            get
            {
                return _strID;
            }
            set
            {
                _strID = value;
                PPC.NotifyPropertyChanged("ID");
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
        public string AddressPatient
        {
            get
            {
                return _addressPatient;
            }
            set
            {
                _addressPatient = value;
                PPC.NotifyPropertyChanged("AddressPatient");
            }
        }
        public string ContactPatient
        {
            get
            {
                return _contactPatient;
            }
            set
            {
                value = _contactPatient;
                PPC.NotifyPropertyChanged("ContactPatient");
            }
        }
        public DateTime LastVisit
        {
            get 
            {
                return _lastVist;
            }
            set
            {
                _lastVist = value;
                PPC.NotifyPropertyChanged("LastVisit");
            }
        }
        public string DoctorName
        {
            get
            {
                return _strDocName;
            }
            set
            {
                _strDocName = value;
                PPC.NotifyPropertyChanged("DoctorName");
            }
        }
        public DateTime NewAppointment
        {
            get
            {
                return _newAppointment;
            }
            set
            {
                _newAppointment = value;
                PPC.NotifyPropertyChanged("NewAppointment");
            }
        }

    }
}
