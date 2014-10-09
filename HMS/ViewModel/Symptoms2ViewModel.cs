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
    public class Symptoms2ViewModel
    {
        private IList<SymptomsDataModel2> ListOfPateient;
        OnChangedProperty PPC = new OnChangedProperty();
        Utils.Utilities Commands = new Utils.Utilities();
        public Symptoms2ViewModel(string strSpecialization, string selectedDate)
        {
            //ListOfPateient = new List<Appointment> { new Appointment("A100", "AyonSir", "RedLight", "100", "LoveGuru", DateTime.Now) };
            ListOfPateient = GetData(strSpecialization, selectedDate);
        }
        private void FillData()
        {
            //OleDbDataReader Data = GetData();
        }
        public IList<SymptomsDataModel2> GetList
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
        private IList<SymptomsDataModel2> GetData(string strSearchValue, string selectedDate)
        {
            IList<SymptomsDataModel2> tempData = null;

            try
            {
                OleDbConnection conn = Commands.GetConnection();
                OleDbDataReader reader = null;
                List<SymptomsDataModel2> tempdata2 = new List<SymptomsDataModel2>();
                if (conn != null)
                {
                    if (string.IsNullOrEmpty(strSearchValue) == false)
                    {
                        if(selectedDate != "")
                        {
                            reader = Commands.GetDataReader("SELECT d.Doc_Name,d.Doc_Id, d.Phone, d.Email,ds.AvailableDate,ds.AvailableStartTime FROM Doctor_Information d, Specialization s, Doctor_Schedule ds WHERE s.Doc_Id = d.Doc_Id AND ds.DoctorID = d.Doc_Id AND ds.AvailableStartTime <> ds.AvailableEndTime AND s.Speciality = '" + strSearchValue + "' AND ds.AvailableDate =DateValue('" + selectedDate + "');", conn);
                        }
                        else
                        {
                            reader = Commands.GetDataReader("SELECT d.Doc_Name,d.Doc_Id, d.Phone, d.Email,ds.AvailableDate,ds.AvailableStartTime FROM Doctor_Information d, Specialization s, Doctor_Schedule ds WHERE s.Doc_Id = d.Doc_Id AND ds.DoctorID = d.Doc_Id AND ds.AvailableStartTime <> ds.AvailableEndTime AND s.Speciality = '" + strSearchValue + "';", conn);
                        }
                    } 

                }
                while (reader.Read())
                {
                    SymptomsDataModel2 tempApp = new SymptomsDataModel2();
                    tempApp.Name = reader["Doc_Name"].ToString();
                    tempApp.Contact = reader["Phone"].ToString();
                    tempApp.Email = reader["Email"].ToString();
                    tempApp.DoctorID = reader["Doc_Id"].ToString();
                    DateTime tempDate = Convert.ToDateTime(reader["AvailableDate"].ToString());
                    tempApp.Date = tempDate.Date.ToString("d");
                    DateTime tempTime = Convert.ToDateTime(reader["AvailableStartTime"].ToString());
                    tempApp.Time = Convert.ToString(tempTime.TimeOfDay);
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
