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
using HMS.Model;
using System.Data.OleDb;

namespace HMS.View
{
    /// <summary>
    /// Interaction logic for PatientDetails.xaml
    /// </summary>
    public partial class PatientDetails : Window
    {
        private Utils.Utilities Commands = new Utils.Utilities();
        private string _appointmentID;
        private string _docID;
        public PatientDetails(DoctorPatientListDataModel selectedPatient, string strDoc_ID)
        {
            InitializeComponent();
            DataContext = new PatientDetailsViewModel(selectedPatient);
            _appointmentID = selectedPatient.AppointmentID;
            _docID = strDoc_ID;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string myDocspath = (DataContext as PatientDetailsViewModel).SetPatientData.FolderLoc;
            string windir = Environment.GetEnvironmentVariable("WINDIR");
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = windir + @"\explorer.exe";
            prc.StartInfo.Arguments = myDocspath;
            prc.Start();
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            PatientDetailsViewModel temp = (DataContext as PatientDetailsViewModel);
            
            OleDbConnection conn = Commands.GetConnection();
            if (conn != null)
            {
                 OleDbCommand cmd = new OleDbCommand();
                //cmd.CommandText = "UPDATE [Patient_History] SET [BloodGroup] = @BloodGroup , [Diagnosis] = @Diagnosis , [BP] = @BP , [BS] = @BS , [Urine] = @Urine , [WBC] = @WBC , [RBC] = @RBC , [Weight] = @Weight WHERE Patient_Id = @patientid and Appointment_id = ";
                 cmd.CommandText = "INSERT INTO Patient_History (BloodGroup,Diagnosis,BP,BS,Urine,WBC,RBC,Weight,Patient_Id,Appointment_id,Doc_Id) VALUES(@BloodGroup,@Diagnosis ,  @BP ,  @BS ,@Urine , @WBC , @RBC , @Weight, @patientid , @AppointmentID,@Doc_Id) ";
                cmd.Parameters.AddWithValue("@BloodGroup", temp.SetPatientData.BloodGroup.ToString());
                cmd.Parameters.AddWithValue("@Diagnosis", temp.SetPatientData.Diagonsis.ToString());
                cmd.Parameters.AddWithValue("@BP", temp.SetPatientData.BloodPressure.ToString());
                cmd.Parameters.AddWithValue("@BS", temp.SetPatientData.BloodSugar.ToString());
                cmd.Parameters.AddWithValue("@Urine", temp.SetPatientData.Urine.ToString());
                cmd.Parameters.AddWithValue("@WBC", temp.SetPatientData.WBC.ToString());
                cmd.Parameters.AddWithValue("@RBC", temp.SetPatientData.RBC.ToString());
                cmd.Parameters.AddWithValue("@Weight", temp.SetPatientData.Weight.ToString());
                cmd.Parameters.AddWithValue("@patientid", temp.SetPatientData.PatientID.ToString());
                cmd.Parameters.AddWithValue("@AppointmentID", _appointmentID);
                cmd.Parameters.AddWithValue("Doc_Id", _docID);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
