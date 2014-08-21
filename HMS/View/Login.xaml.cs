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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using HMS.View;
using HMS.Utils;
using HMS.ViewModel;
using System.Data.OleDb;

namespace HMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    { public Utils.Utilities Commands = new Utilities();
     LoginViewModel LoginData = new LoginViewModel();
        public Login()
        {
            InitializeComponent();
        }   
        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection conn = Commands.GetConnection();
            OleDbDataReader temp = Commands.GetDataReader(SQLQueryLogin(), conn);
            if (temp.HasRows == true)
            {
                int i = 0;
                string Group = string.Empty;

                while (temp.Read() && i<2)
                {
                    Group = temp["Group"].ToString();
                }
                if (string.IsNullOrEmpty(Group) == false)
                {
                    if (Group.Equals("A")==true)
                    {
                        Appointment varAppointment = new Appointment();
                        varAppointment.Show();
                       
                    }
                    if (Group.Equals("D") == true )
                    {
                        Doctor varAppointment = new Doctor();
                        varAppointment.Show();

                    }
                }
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Incorrect credentials");
            }
           
            Commands.DBClose(conn);
          
        }
        private string SQLQueryLogin()
        {
            string SQlStart = "Select * from Login where UId='";
            if((string.IsNullOrEmpty(LoginData.LoginData.UserID)==false)&&(string.IsNullOrEmpty(LoginData.LoginData.Password)==false))
            {
                SQlStart = SQlStart + LoginData.LoginData.UserID + "' AND Password = '" + LoginData.LoginData.Password + "';";
            }
            return SQlStart;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CanvasLogin.DataContext = LoginData;
        }
    }
}
