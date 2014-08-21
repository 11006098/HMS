using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Utils;
namespace HMS.Model
{
    public class Appointment
    {
        private string _strPatientID;
        private string _strPatientName;
        private string _strPatientAddress;
        private string _strPatientContact;
        private string _strDocID;
        private DateTime _newAppointment;
        private OnChangedProperty PPC = new OnChangedProperty();
        
        
        public Appointment() { }
        //public Appointment(string id, string patientName, string addressPatient, string contactPatient, 
        //    string docName, DateTime newAppointment)
        //{
        //    PatientID = id;
        //    PatientName = patientName;
        //    PatientAddress = addressPatient;
        //    PatientContact = contactPatient;
        //    DoctorName = docName;
        //    NewAppointment = newAppointment;
        //}

        public string PatientID
        {
            get
            {
                return _strPatientID;
            }
            set
            {
                _strPatientID = value;
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
        public string PatientAddress
        {
            get
            {
                return _strPatientAddress;
            }
            set
            {
                _strPatientAddress = value;
                PPC.NotifyPropertyChanged("AddressPatient");
            }
        }
        public string PatientContact
        {
            get
            {
                return _strPatientContact;
            }
            set
            {
                _strPatientContact = value;
                PPC.NotifyPropertyChanged("PatientContact");
            }
        }
        
        public string DoctorName
        {
            get
            {
                return _strDocID;
            }
            set
            {
                _strDocID = value;
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
