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
            this.DataContext = new AppointmentViewModel();
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new AppointmentViewModel();
        }
        private void txtboxPatientID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void PatientList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HMS.Model.Appointment currentSelection = PatientList.SelectedItem as HMS.Model.Appointment;
            if (currentSelection != null)
            {
                Symptoms symptomsWindow = new Symptoms();
                symptomsWindow.ShowDialog();

            }
        }
       
    }
}
