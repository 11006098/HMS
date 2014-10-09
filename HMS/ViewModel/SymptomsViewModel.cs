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
    public class SymptomsViewModel
    {
        private IList<SymptomsDataModel> ListOfSymptoms;
        OnChangedProperty PPC = new OnChangedProperty();
        Utils.Utilities Commands = new Utils.Utilities();
        public SymptomsViewModel()
        {
            ListOfSymptoms = GetData();
        }
        public IList<SymptomsDataModel> GetListSymptoms
        {
            get
            {
                return ListOfSymptoms;
            }
            set
            {
                ListOfSymptoms = value;
                PPC.NotifyPropertyChanged("GetList");
            }
        }
        private IList<SymptomsDataModel> GetData()
        {
            IList<SymptomsDataModel> tempData = null;
            try
            {
                OleDbConnection conn = Commands.GetConnection();
                OleDbDataReader reader = null;
                List<SymptomsDataModel> tempdata2 = new List<SymptomsDataModel>();
                if (conn != null)
                {
                    reader = Commands.GetDataReader("SELECT * FROM Specialization", conn);
                   
                }
                while (reader.Read())
                {
                    SymptomsDataModel tempApp = new SymptomsDataModel();
                    tempApp.Specialization = reader["Speciality"].ToString();
                   

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
