using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Utils;

namespace HMS.Model
{
    public class Login
    {
        private string _useriD;
        private string _password;
        private OnChangedProperty PPC = new OnChangedProperty();
        public string UserID
        {
            get
            {
                return _useriD;
            }
            set
            {
                _useriD = value;
                PPC.NotifyPropertyChanged("UserID");
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                PPC.NotifyPropertyChanged("Password");
            }
        }
    }
}
