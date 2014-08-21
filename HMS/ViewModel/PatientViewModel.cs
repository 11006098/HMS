using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Model;
using HMS.Utils;
namespace HMS.ViewModel
{
   public class PatientViewModel
    {
       public IList<Patient> ListOfPateient ;
       OnChangedProperty PPC = new OnChangedProperty();
       public PatientViewModel()
       {
           Patient newPatient = new Patient("A100", "AyonSir", "RedLight", "100", DateTime.Now, "LoveGuru", DateTime.Now);
           ListOfPateient.Add(newPatient);
       }
       public IList<Patient> GetList
       {
           get
           {
               return ListOfPateient;
           }
           set
           {
               ListOfPateient = value;
               PPC.NotifyPropertyChanged("GetList");
           }
       }

    }
}
