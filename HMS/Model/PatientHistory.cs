using HMS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    class PatientHistory
    {

        private string _strPatientID;
        private string _strDoctorID;
        private string _strAppointmentID;
        private string _strDiagnosis;
        private string _BP;
        private string _BS;
        private string _Urine;
        private string _WBC;
        private string _RBC;
        private string _Weight;
        private string _FolderLoc;

        private OnChangedProperty PPC = new OnChangedProperty();


        public PatientHistory() { }
        public PatientHistory(string inPatientID, string inDoctorID, string inAppointmentID, string inDiagnosis, string inBP,
        string inBS, string inUrine, string inWBC, string inRBC, string inWeight, string inFolderLoc)
        {
            PatientID = inPatientID;
            DoctorID = inDoctorID;
            AppointmentID = inAppointmentID;
            Diagnosis = inDiagnosis;
            BP = inBP;
            BS = inBS;
            Urine = inUrine;
            WBC = inWBC;
            RBC = inRBC;
            Weight = inWeight;
            FolderLoc = inFolderLoc;
        }

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

        public string DoctorID
        {
            get
            {
                return _strDoctorID;
            }
            set
            {
                _strDoctorID = value;
                PPC.NotifyPropertyChanged("DoctorID");
            }
        }

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

        public string Diagnosis
        {
            get
            {
                return _strDiagnosis;
            }
            set
            {
                _strDiagnosis = value;
                PPC.NotifyPropertyChanged("Diagnosis");
            }
        }

        public string BP
        {
            get
            {
                return _BP;
            }
            set
            {
                _BP = value;
                PPC.NotifyPropertyChanged("BP");
            }
        }

        public string BS
        {
            get
            {
                return _BS;
            }
            set
            {
                _BS = value;
                PPC.NotifyPropertyChanged("BS");
            }
        }

        public string Urine
        {
            get
            {
                return _Urine;
            }
            set
            {
                _Urine = value;
                PPC.NotifyPropertyChanged("Urine");
            }
        }

        public string WBC
        {
            get
            {
                return _WBC;
            }
            set
            {
                _WBC = value;
                PPC.NotifyPropertyChanged("WBC");
            }
        }

        public string RBC
        {
            get
            {
                return _RBC;
            }
            set
            {
                _RBC = value;
                PPC.NotifyPropertyChanged("RBC");
            }
        }

        public string Weight
        {
            get
            {
                return _Weight;
            }
            set
            {
                _Weight = value;
                PPC.NotifyPropertyChanged("Weight");
            }
        }

        public string FolderLoc
        {
            get
            {
                return _FolderLoc;
            }
            set
            {
                _FolderLoc = value;
                PPC.NotifyPropertyChanged("FolderLoc");
            }
        }		
		
	
    }
}
