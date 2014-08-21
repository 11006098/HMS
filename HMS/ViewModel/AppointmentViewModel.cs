using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Model;
using HMS.Utils;
using System.Data.OleDb;
using HMS.Utils;
namespace HMS.ViewModel
{
   public class AppointmentViewModel
    {
       private IList<Appointment> ListOfPateient ;
       OnChangedProperty PPC = new OnChangedProperty();
       Utils.Utilities Commands = new Utils.Utilities();
       public AppointmentViewModel()
       {
           //ListOfPateient = new List<Appointment> { new Appointment("A100", "AyonSir", "RedLight", "100", "LoveGuru", DateTime.Now) };
           ListOfPateient = GetData();
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
       private IList<Appointment> GetData()
       {
           OleDbConnection conn = Commands.GetConnection();
           OleDbDataReader reader = null;
           IList<Appointment> tempData = null;
           List<Appointment> tempdata2 = new List<Appointment>();
           if (conn != null)
           {
                reader = Commands.GetDataReader("SELECT Patient_Information.Patient_Id, Patient_Information.Patient_Name, Patient_Information.Address, Patient_Information.Phone FROM Patient_Information;",conn);
           }
           while (reader.Read())
           {
               Appointment tempApp = new Appointment();
               tempApp.PatientID = reader["Patient_Id"].ToString();
               tempApp.PatientName = reader["Patient_Name"].ToString();
               tempApp.PatientAddress = reader["Address"].ToString();
               tempApp.PatientContact = reader["Phone"].ToString();
               
               tempdata2.Add(tempApp);
           }
           tempData = tempdata2;
           Commands.DBClose(conn);
           return tempData;
       }
    }
}
