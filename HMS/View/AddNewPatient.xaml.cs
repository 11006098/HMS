using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HMS.ViewModel;
using HMS.Utils;
using System.Data.OleDb;
namespace HMS.View
{
    /// <summary>
    /// Interaction logic for AddNewPatient.xaml
    /// </summary>
    public partial class AddNewPatient : Window
    {
        private NewPatientViewModel currentData ;
        private Utilities Command = new Utilities();
        public AddNewPatient()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection conn = Command.GetConnection();
            try
            {
                if (conn != null)
                {
                    
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = "INSERT INTO Patient_Information (Patient_Id,Patient_Name,Patient_Age,Sex,Address,Phone,Email_address,Folder_Loc,DOB) VALUES (@Patient_Id,@Patient_Name,@Patient_Age,@Sex,@Address,@Phone,@Email_address,@Folder_Loc,@DOB)";
                    cmd.Parameters.AddWithValue("@Patient_Id", currentData.SetNewPatient.PatientID);
                    cmd.Parameters.AddWithValue("@Patient_Name", currentData.SetNewPatient.PatientName);
                    cmd.Parameters.AddWithValue("@Patient_Age", currentData.SetNewPatient.PatientAge);
                    cmd.Parameters.AddWithValue("@Sex", currentData.SetNewPatient.PatientGender);
                    cmd.Parameters.AddWithValue("@Address", currentData.SetNewPatient.PatientAddress);
                    cmd.Parameters.AddWithValue("@Phone", currentData.SetNewPatient.PatientPhone);
                    cmd.Parameters.AddWithValue("@Email_address", currentData.SetNewPatient.PatientEmail);
                    cmd.Parameters.AddWithValue("@Folder_Loc", currentData.SetNewPatient.FolderLocation);
                    cmd.Parameters.AddWithValue("@DOB", currentData.SetNewPatient.PatientDOB);
                   
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Command.DBClose(conn);
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            currentData = new NewPatientViewModel();
            DataContext = currentData;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
