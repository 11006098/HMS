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
namespace HMS.View
{
    /// <summary>
    /// Interaction logic for Doctor1.xaml
    /// </summary>
    public partial class Doctor : Window
    {
        private string _id;
        public Doctor(string strDoctor_ID)
        {
            if (string.IsNullOrEmpty(strDoctor_ID) == false)
            {
                InitializeComponent();
                DataContext = new DoctorViewModel(strDoctor_ID);
                _id = strDoctor_ID;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DoctorPatientListDataModel temp = AppointmentList.SelectedItem as DoctorPatientListDataModel;
            PatientDetails patient = new PatientDetails(temp, _id);
            patient.ShowDialog();
        }
    }
}
