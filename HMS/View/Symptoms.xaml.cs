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
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using HMS.Model;
using HMS.Utils;
using System.Data.OleDb;
namespace HMS.View
{
    /// <summary>
    /// Interaction logic for Symptoms.xaml
    /// </summary>
    public partial class Symptoms : Window
    {
        private Utils.Utilities Commands = new Utilities();
        private string patientID;
        public Symptoms(string inpatientID)
        {
            patientID = inpatientID;
            InitializeComponent();
            this.DataContext = new SymptomsViewModel();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
            
        {
            SymptomsDataModel Temp = txtBoxSymtomps.SelectedItem as SymptomsDataModel;
            this.ListDoctor.DataContext = new Symptoms2ViewModel(Temp.Specialization, AppointmentDate.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name); 
            ci.DateTimeFormat.ShortDatePattern = "dd-MMM-yy";
            Thread.CurrentThread.CurrentCulture = ci; 
        }

        private void ListDoctor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int aaa = 0;
                TimeSpan convTime;
                DateTime convDate;
                SymptomsDataModel2 temp = ListDoctor.SelectedItem as SymptomsDataModel2;
                OleDbConnection conn = Commands.GetConnection();
                OleDbCommand cmd = new OleDbCommand();
                OleDbCommand cmd1 = new OleDbCommand();
                
                //Query = "UPDATE [Doctor_Schedule] SET [Doctor_Schedule.AvailableStartTime] = TimeValue('9.00')WHERE (((Doctor_Schedule.[DoctorID])='D1') AND ((Doctor_Schedule.[AvailableDate])=DateValue('1-Aug-14')) AND ((Doctor_Schedule.[AvailableStartTime])=TimeValue('8:00')))";
                 
                //cmd.CommandText = "UPDATE [Doctor_Schedule] SET [AvailableStartTime] = @DocStartTime WHERE ((([DoctorID])=@DocID) AND (([AvailableDate])=@DocSechudleAvaliableDate) AND (([AvailableStartTime])=@DocSechudleAvaliableTime))";
                cmd.CommandText = "UPDATE Doctor_Schedule SET Doctor_Schedule.AvailableStartTime = TimeValue(@DocStartTime) WHERE (((Doctor_Schedule.DoctorID)=@DocID) AND ((Doctor_Schedule.AvailableDate)=DateValue(@DocSechudleAvaliableDate)))";
                convTime = Convert.ToDateTime(temp.Time).AddHours(1).TimeOfDay;
                cmd.Parameters.AddWithValue("@DocStartTime", convTime.ToString());
                cmd.Parameters.AddWithValue("@DocID", temp.DoctorID);
                //convTime = Convert.ToDateTime(temp.Time).TimeOfDay;
                //cmd.Parameters.AddWithValue("@DocSechudleAvaliableTime", convTime.ToString());
                convDate = Convert.ToDateTime(temp.Date).Date;
                cmd.Parameters.AddWithValue("@DocSechudleAvaliableDate", convDate.ToString());
                cmd.Connection = conn;
                conn.Open();
                aaa=cmd.ExecuteNonQuery();
                conn.Close();
                this.Close();

                
                //INSERT INTO Appointment (Appointment_id, Patient_Id, Doctor_Id, AppDate, StartTime, EndTime) VALUES (4,"P4","D2",DateValue("1-Aug-14"),TimeValue("11:45"),TimeValue ("14:02") );
                //cmd1.CommandText = "INSERT INTO Appointment (Appointment_id, Patient_Id, Doctor_Id) VALUES (@Appointment_id, @Patient_Id, @Doctor_Id)";
                cmd1.CommandText = "INSERT INTO Appointment (Patient_Id, Doctor_Id, AppDate, StartTime, EndTime) VALUES ( @Patient_Id, @Doctor_Id, @AppDate, @StartTime, @EndTime)";
                cmd1.Parameters.AddWithValue("@Patient_Id", patientID.ToString());
                cmd1.Parameters.AddWithValue("@Doctor_Id", temp.DoctorID.ToString());
                cmd1.Parameters.AddWithValue("@AppDate", Convert.ToDateTime(temp.Date).Date);
                cmd1.Parameters.AddWithValue("@StartTime", Convert.ToDateTime(temp.Time).TimeOfDay);
                cmd1.Parameters.AddWithValue("@EndTime", Convert.ToDateTime(temp.Time).AddHours(1).TimeOfDay);   

                cmd1.Connection = conn;
                conn.Open();
                aaa=cmd1.ExecuteNonQuery();
                conn.Close();

            }
            catch(Exception ex)
            {

            }
        }
    }
}
