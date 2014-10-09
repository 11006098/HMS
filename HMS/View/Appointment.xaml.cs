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

namespace HMS.View
{
    /// <summary>
    /// Interaction logic for Assistant2.xaml
    /// </summary>
    public partial class Appointment : Window
    {
        public Appointment()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddNewPatient patientAdd = new AddNewPatient();
            patientAdd.ShowDialog();
            this.DataContext = new AppointmentViewModel(string.Empty);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new AppointmentViewModel(txtboxPatientID.Text);
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new AppointmentViewModel(string.Empty);
        }

        private void txtboxPatientID_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void PatientList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Model.Appointment temp = PatientList.SelectedItem as Model.Appointment;
            Symptoms newSymptoms = new Symptoms(temp.PatientID);
            newSymptoms.ShowDialog();
            //Model.Appointment temp = PatientList.SelectedItem as Model.Appointment;
            this.DataContext = new AppointmentViewModel(temp.PatientID);
        }
       
    }
}
