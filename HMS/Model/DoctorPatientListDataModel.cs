using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Utils;
namespace HMS.Model
{
    public class DoctorPatientListDataModel
    {
        private OnChangedProperty PPC = new OnChangedProperty();
        private string _strPatientName;
        private string _strAppointmentDate;
        private string _strDetails;
        private string _strFolderLocation;
        private string _strPatient_ID;
        private string _strAppointmentID;
        public string AppointmentID
        {
            get
            {
                return _strAppointmentID;
            }
            set
            {
                _strAppointmentID = value;
                PPC.NotifyPropertyChanged("AppointmentID");
            }
        } 
        public string PatientID
        {
            get
            {
                return _strPatient_ID;
            }
            set
            {
                _strPatient_ID = value;
                PPC.NotifyPropertyChanged("PatientID");
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
        public string PateientName
        {
            get
            {
                return _strPatientName;
            }
            set
            {
                _strPatientName = value;
                PPC.NotifyPropertyChanged("PateientName");
            }
        }
        public string AppointmentDate
        {
            get
            {
                return _strAppointmentDate;
            }
            set
            {
                _strAppointmentDate = value;
                PPC.NotifyPropertyChanged("AppointmentDate");
            }
        }
        public string Details
        {
            get
            {
                return _strDetails;
            }
            set
            {
                _strDetails = value;
                PPC.NotifyPropertyChanged("Details");
            }
        }
    }
}
