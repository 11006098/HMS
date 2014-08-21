using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Model;

namespace HMS.ViewModel
{
    public class LoginViewModel
    {
        private LoginModel login = new LoginModel();
        public LoginViewModel()
        {
            login = LoginData;
        }
        public LoginModel LoginData
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }
    }
}
