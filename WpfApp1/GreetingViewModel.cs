using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class GreetingViewModel : INotifyPropertyChanged
    {
        public List<String> listAffich = new List<string>();
        private Dictionary<string, List<ArrayJson>> arrets;
        public Dictionary<string, List<ArrayJson>> Arrets
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

        public GreetingViewModel()
        {
            Arrets = new Dictionary<string, List<ArrayJson>>();
            

        }
        public event PropertyChangedEventHandler PropertyChanged;



        public void remplirArrets(String lat, String lon, String dist)
        {
            UtilApi api = new UtilApi(lat, lon);
            Dictionary<string, List<ArrayJson>> DictionnaireArrets = api.getListLigne(int.Parse(dist));

            List<String> listeAAfficher = new List<String>();
            foreach (KeyValuePair<string, List<ArrayJson>> ListArrayJson in DictionnaireArrets)
            {
                listeAAfficher.Add(ListArrayJson.Key);
                /*foreach (ArrayJson objectArray in ListArrayJson.Value)
                {
                    foreach (String idLigne in objectArray.lines)
                    {
                        listeAAfficher.Add(idLigne);
                    }
                }*/

            }

            listAffich = listeAAfficher;
            Arrets = DictionnaireArrets;
        }

        protected bool SetProperty(ref Dictionary<string, List<ArrayJson>> storage, Dictionary<string, List<ArrayJson>> value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        ///
        /// Notifies listeners that a property value has changed.
        ///
        ///Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support .
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

    
