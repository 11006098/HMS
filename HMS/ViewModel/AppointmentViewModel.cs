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
    public class AppointmentViewModel
    {
        private IList<Appointment> ListOfPateient;
        OnChangedProperty PPC = new OnChangedProperty();
        Utils.Utilities Commands = new Utils.Utilities();
        public AppointmentViewModel(string strSearchValue)
        {
            ListOfPateient = GetData(strSearchValue);
        }
        private void FillData()
        {
            //OleDbDataReader Data = GetData();
        }
        public IList<Appointment> GetList
        {
            get
            {
                return ListOfPateient;
            }
            set
            {
                ListOfPateient = value;
                PPC.NotifyPropertyChanged("GetList");
            }
        }
        private IList<Appointment> GetData(string strSearchValue)
        {
            IList<Appointment> tempData = null;

            try
            {
                OleDbConnection conn = Commands.GetConnection();
                OleDbDataReader reader = null;
                List<Appointment> tempdata2 = new List<Appointment>();
                if (conn != null)
                {
                    if (string.IsNullOrEmpty(strSearchValue) == true)
                    {
                        //reader = Commands.GetDataReader("SELECT Patient_Information.Patient_Id, Patient_Information.Patient_Name, Patient_Information.Address, Patient_Information.Phone FROM Patient_Information;", conn);
                        reader = Commands.GetDataReader("SELECT Patient_Information.Patient_Id, Patient_Information.Patient_Name, Patient_Information.Address, Patient_Information.Phone, Appointment.Doctor_ID ,Appointment.AppDate, Appointment.StartTime FROM Patient_Information LEFT JOIN Appointment ON Patient_Information.Patient_ID = Appointment.Patient_ID ORDER BY Patient_Information.Patient_ID;", conn);
                    } 
                    else
                    {
                        reader = Commands.GetDataReader("SELECT Patient_Information.Patient_Id, Patient_Information.Patient_Name, Patient_Information.Address, Patient_Information.Phone, Appointment.Doctor_ID ,Appointment.AppDate, Appointment.StartTime FROM Patient_Information LEFT JOIN Appointment ON Patient_Information.Patient_ID = Appointment.Patient_ID WHERE Patient_Information.Patient_Id  ='" + strSearchValue + "' or Patient_Information.Patient_Name  ='" + strSearchValue + "';", conn);
                    }

                }
                while (reader.Read())
                {
                    Appointment tempApp = new Appointment();
                    tempApp.PatientID = reader["Patient_Id"].ToString();
                    tempApp.PatientName = reader["Patient_Name"].ToString();
                    tempApp.PatientAddress = reader["Address"].ToString();
                    tempApp.PatientContact = reader["Phone"].ToString();
                    if(string.IsNullOrEmpty(Convert.ToString(reader["AppDate"].ToString()))==false)
                    {
                        tempApp.DoctorName = reader["Doctor_ID"].ToString();
                        string tempDate = reader["AppDate"].ToString().Substring(0, 8);
                        tempApp.Date = tempDate.ToString();
                        DateTime tempTime = Convert.ToDateTime(reader["StartTime"]);
                        tempApp.Time = Convert.ToString(tempTime.TimeOfDay);
                    }
                    tempdata2.Add(tempApp);
                }
                tempData = tempdata2;
                Commands.DBClose(conn);
                
            }
            catch (Exception ex)
            {
 
            }
            return tempData;

            }
        }
                
    
}
