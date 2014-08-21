using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Model;
using HMS.Utils;

namespace HMS.ViewModel
{
    public class NewPatientViewModel
    {
        private  HMS.Model.NewPatient _newPatient = new Model.NewPatient();
        private Utilities Command = new Utilities();
        private Utils.OnChangedProperty ppc = new OnChangedProperty();
        public NewPatientViewModel()
        {
            _newPatient.PatientID = Command.GetID("Patient_Information", "Patient_Id");
             _newPatient.FolderLocation = CreateFolder(_newPatient.PatientID);
             _newPatient.PatientDOB = DateTime.Today;
        }
        private string CreateFolder(string strFolderName)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(HMS.Properties.Resources.FolderDir) == false)
            {
                string NewFolderPath = HMS.Properties.Resources.FolderDir + _newPatient.PatientID;
                System.IO.Directory.CreateDirectory(NewFolderPath);
                if (System.IO.Directory.Exists(NewFolderPath) == true)
                {
                    result = NewFolderPath;
                }
            }
            return result;
        }
        public NewPatient SetNewPatient
        {
            get
            {
                return _newPatient;
            }
            set
            {
                _newPatient = value;
            }
        }
        
    }
}
