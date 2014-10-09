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
    public class DoctorViewModel
    {
        private DoctorModel _doctorDetails = new DoctorModel();
        Utils.Utilities Commands = new Utils.Utilities();
        public DoctorViewModel(string strDocID)
        {
            _doctorDetails = FillData(strDocID);
        }
        private DoctorModel FillData(string strDocID)
        {
            DoctorModel tempData = new DoctorModel();
            OleDbConnection conn = Commands.GetConnection();
            OleDbDataReader reader1 = null;
            OleDbDataReader reader2 = null;

            if (conn != null)
            {
                reader1 = Commands.GetDataReader("SELECT * FROM Doctor_Information WHERE Doctor_Information.Doc_ID = '" + strDocID + "';", conn);
                if (reader1 != null)
                {
                    while(reader1.Read())
                    {
                        tempData.DoctorID = reader1["Doc_Id"].ToString();
                        tempData.DoctorName = reader1["Doc_Name"].ToString();
                    }
                }
                Commands.DBClose(conn);

                reader2 = Commands.GetDataReader("Select Patient_Information.Patient_Name,Patient_Information.Folder_Loc, Appointment.Patient_Id,Appointment.AppDate, Appointment.StartTime ,Appointment.Appointment_Id FROM Appointment, Patient_Information WHERE Appointment.Doctor_Id = '" + strDocID + "' AND Appointment.Patient_Id = Patient_Information.Patient_Id;", conn);
                if(reader2!=null)
                {
                    while(reader2.Read())
                    {
                        tempData.PatientList.Add(new DoctorPatientListDataModel { AppointmentID = reader2["Appointment_id"].ToString(), PateientName = reader2["Patient_Name"].ToString(), PatientID = reader2["Patient_Id"].ToString(), AppointmentDate = reader2["AppDate"].ToString().Substring(0, 8).ToString(), Details = Convert.ToDateTime(reader2["StartTime"].ToString()).TimeOfDay.ToString(), FolderLocation = reader2["Folder_Loc"].ToString() });
                    }
                }
                Commands.DBClose(conn);

            }
            return tempData;
        }
        public DoctorModel SetDoctorInformation
        {
            get
            {
                return _doctorDetails;
            }
            set
            {
                _doctorDetails = value;
            }
        }
    }
}
