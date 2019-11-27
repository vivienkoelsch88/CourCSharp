using ConsoleApp2;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

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
        public String lat;
        public String Lat
        {
            get { return lat; }
            set
            {
                if (value != lat)
                {
                    lat = value;
                    OnPropertyChanged("Lat");
                }
            }
        }
        public String lon;
        public String Lon
        {
            get { return lon; }
            set
            {
                if (value != lon)
                {
                    lon = value;
                    OnPropertyChanged("Lon");
                }
            }
        }
        public String dist;
        public String Dist
        {
            get { return dist; }
            set
            {
                if (value != dist)
                {
                    dist = value;
                    OnPropertyChanged("Dist");
                }
            }
        }
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction(), () => CanExecute));
            }
        }

        public List<String> listPoint;
        public List<String> ListPoint
        {
            get { return listPoint; }
            set
            {
                if (value != listPoint)
                {
                    listPoint = value;
                    OnPropertyChanged("ListPoint");
                }
            }
        }

        private object MyAction()
        {
            this.remplirArrets(this.Lat, this.Lon, this.Dist);
            return null;
        }

        public bool CanExecute
        {
            get
            {
                return true;
            }
        }
        

        public GreetingViewModel()
        {
            Arrets = new Dictionary<string, List<ArrayJson>>();
            this.lat = "5.727718";
            this.lon = "45.185603";
            this.dist = "500";
            


        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void remplirArrets(String lat, String lon, String dist)
        {
            UtilApi api = new UtilApi(lat, lon);
            Dictionary<string, List<ArrayJson>> DictionnaireArrets = api.getListLigne(int.Parse(dist));
            List<String> points = new List<string>();
            
            Arrets = DictionnaireArrets;

            foreach (KeyValuePair<string, List<ArrayJson>> element in DictionnaireArrets)
            {
                foreach (ArrayJson p in element.Value)
                {
                    String po = p.lon + "";
                    String la = p.lat + "";
                    points.Add(la.Replace(",",".") + "," + po.Replace(",","."));
                }
            }
            this.ListPoint = points;
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

        private async void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Specify a known location.
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 5.727718, Longitude = 45.185603 };
            var cityCenter = new Geopoint(cityPosition);

            // Set the map location.
            await (sender as MapControl).TrySetViewAsync(cityCenter, 12);
        }


    }
}


