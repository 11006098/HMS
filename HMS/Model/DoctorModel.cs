using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Utils;
using HMS.Model;
namespace HMS.Model
{
    public class DoctorModel
    {
        private OnChangedProperty PPC = new OnChangedProperty();
        private string _DoctorName;
        private string _DoctorID;
        private List<DoctorPatientListDataModel> _patientList = new List<DoctorPatientListDataModel>();
        public string DoctorName
        {
            get
            {
                return _DoctorName;
            }
            set
            {
                _DoctorName = value;
                PPC.NotifyPropertyChanged("DoctorName");
            }
        }
        public string DoctorID
        {
            get
            {
                return _DoctorID;
            }
            set
            {
                _DoctorID = value;
                PPC.NotifyPropertyChanged("DoctorID");
            }
        }
        public List<DoctorPatientListDataModel> PatientList
        {
            get
            {
                return _patientList;
            }
            set
            {
                _patientList = value;
                PPC.NotifyPropertyChanged("PatientList");
            }
        }
        
    }
}
