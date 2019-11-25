using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ArrayJsonViewModel : UtilApi
    {

        private List<ArrayJson> arrets;
        public List<ArrayJson> Arrets
        {
            get
            {
                return arrets;
            }
            set
            {
                SetProperty(ref arrets, value);
            }
        }

        public ArrayJsonViewModel()
        {
            Arrets = new List<ArrayJson>();

        }

    }
}

    
