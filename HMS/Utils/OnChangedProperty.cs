using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HMS.Utils
{
    public class OnChangedProperty : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(params string[] propNames)
            {
                if (this.PropertyChanged != null)
                {
                    foreach (string propName in propNames)
                    {
                        this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
                    }
                }
            }
            #endregion    
    }
}
