using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Model;
using HMS.Utils;
using System.Data.OleDb;

namespace HMS.ViewModel
{
    public class PatientDetailsViewModel
    {
        private PatientHistory _patientData = new PatientHistory();
        OnChangedProperty PPC = new OnChangedProperty();
        Utils.Utilities Commands = new Utils.Utilities();
        public PatientDetailsViewModel(DoctorPatientListDataModel selectedPatient)
        {
            _patientData = FillData(selectedPatient);
        }

        private PatientHistory FillData(DoctorPatientListDataModel selectedPatient)
        {
            PatientHistory temp = new PatientHistory();
            temp.PatientName = selectedPatient.PateientName;
            temp.PatientID = selectedPatient.PatientID;
            temp.FolderLoc = selectedPatient.FolderLocation;
            ////Query = Select Patient_Information.Patient_Name,Patient_Information.Patient_Id  FROM Appointment,Patient_Information WHERE Patient_Information.Patient_Id = 'P2';
            OleDbConnection conn = Commands.GetConnection();
            //if (conn != null)
            //{
            //    OleDbDataReader reader = Commands.GetDataReader("Select Patient_Information.Patient_Name,Patient_Information.Patient_Id  FROM Appointment,Patient_Information WHERE Patient_Information.Patient_Id = '" + selectedPatient.PatientID + "';", conn);
            //    if(reader!=null)
            //    {
            //        while(reader.Read())
            //        {
            //            temp.PatientID = reader["Patient_Id"].ToString();
            //            temp.PatientName = reader["Patient_Name"].ToString();
            //        }
            //    }
            //    Commands.DBClose(conn);
            //}

            if (conn != null)
            {
                //Select * from Patient_History WHERE Patient_History.Patient_Id = "P2";
                OleDbDataReader reader1 = Commands.GetDataReader("Select * from Patient_History WHERE Patient_History.Patient_Id = '" + selectedPatient.PatientID + "';", conn);
                if (reader1 != null)
                {
                    while (reader1.Read())
                    {
                        temp.BloodGroup = reader1["BloodGroup"].ToString();
                        temp.Diagonsis = reader1["Diagnosis"].ToString();
                        temp.BloodPressure = reader1["BP"].ToString();
                        temp.BloodSugar = reader1["BS"].ToString();
                        temp.Urine = reader1["URINE"].ToString();
                        temp.WBC = reader1["WBC"].ToString();
                        temp.RBC = reader1["RBC"].ToString();
                        temp.Weight = reader1["Weight"].ToString();
                    }
                }
                Commands.DBClose(conn);
            }
            return temp;
        
        }
        public PatientHistory SetPatientData
        {
            get
            {
                return _patientData;
            }
            set
            {
                _patientData = value;
                PPC.NotifyPropertyChanged("SetPatientData");
            }
        }
    }
}
