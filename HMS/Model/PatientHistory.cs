using HMS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class PatientHistory
    {

        private string _strPatientID;
        private string _strPatientName;
        private string _BloodGroup;
        private string _diagonsis;
        private string _BloodPressure;
        private string _BloodSugar;
        private string _urine;
        private string _wbc;
        private string _rbc;
        private string _Weight;
        private string _FolderLoc;
        
        private string _Height;
        private OnChangedProperty PPC = new OnChangedProperty();

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
        public string Height
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = value;
                PPC.NotifyPropertyChanged("Height");
            }
        }
        public string BloodGroup
        {
            get
            {
                return _BloodGroup;
            }
            set
            {
                _BloodGroup = value;
                PPC.NotifyPropertyChanged("BloodGroup");
            }
        }
        public string Diagonsis
        {
            get
            {
                return _diagonsis;
            }
            set
            {
                _diagonsis = value;
                PPC.NotifyPropertyChanged("Diagonsis");
            }
        }
        public string BloodPressure
        {
            get
            {
                return _BloodPressure;
            }
            set
            {
                _BloodPressure = value;
                PPC.NotifyPropertyChanged("BP");
            }
        }
        public string BloodSugar
        {
            get
            {
                return _BloodSugar;
            }
            set
            {
                _BloodSugar = value;
                PPC.NotifyPropertyChanged("BS");
            }
        }
        public string Urine
        {
            get
            {
                return _urine;
            }
            set
            {
                _urine = value;
                PPC.NotifyPropertyChanged("Urine");
            }
        }
        public string WBC
        {
            get
            {
                return _wbc;
            }
            set
            {
                _wbc = value;
                PPC.NotifyPropertyChanged("WBC");
            }
        }
        public string RBC
        {
            get
            {
                return _rbc;
            }
            set
            {
                _rbc = value;
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
