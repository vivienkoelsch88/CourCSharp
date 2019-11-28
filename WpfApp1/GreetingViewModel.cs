using ClassLibrary1.ClasseRetourApi;
using ConsoleApp2;
using Microsoft.Maps.MapControl.WPF;
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
using System.Windows.Media;
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
                return _clickCommand ?? (_clickCommand = new CommandHandler(param => MyAction(param), () => CanExecute));
            }
        }

        private ICommand cachePushPinClicked;
        public ICommand CachePushPinClicked
        {
            get
            {
                return cachePushPinClicked ?? (cachePushPinClicked = new CommandHandler(param => afficherLigne(param), () => CanExecute));
            }
        }
        
        public List<List<String>> listPoint;
        public List<List<String>> ListPoint
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

        public List<String> listeDesLignesAffichees;
        public List<String> ListeDesLignesAffichees
        {
            get { return listeDesLignesAffichees; }
            set
            {
                if (value != listeDesLignesAffichees)
                {
                    listeDesLignesAffichees = value;
                    OnPropertyChanged("ListeDesLignesAffichees");
                }
            }
        }

        public String color;
        public String Color
        {
            get { return color; }
            set
            {
                if (value != color)
                {
                    color = value;
                    OnPropertyChanged("Color");
                }
            }
        }

        /**
         * 
         * @param 
         */
        private object MyAction(object id)
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
            this.Color = "#399645";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void remplirArrets(String lat, String lon, String dist)
        {
            UtilApi api = new UtilApi(lat, lon);
            Dictionary<string, List<ArrayJson>> DictionnaireArrets = api.getListLigne(int.Parse(dist));
            List<List<String>> points = new List<List<string>>();
            
            Arrets = DictionnaireArrets;

            foreach (KeyValuePair<string, List<ArrayJson>> element in DictionnaireArrets)
            {
                foreach (ArrayJson p in element.Value)
                {
                    List<String> l = new List<string>();
                    String po = p.lon + "";
                    String la = p.lat + "";
                    l.Add(la.Replace(",", ".") + "," + po.Replace(",", "."));
                    l.Add(p.lines[0]);
                    points.Add(l);
                    
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

        public object afficherLigne(object parameter)
        {     
            UtilApi api = new UtilApi(this.Lat, this.Lon);
            GeometryV listePointLigne = api.getTrajetLigne((string)parameter);
            int compteur = 0;
            string ar = "";
            string ar2 = "";
            List<string> listAffichageTrace = new List<string>();

            foreach (List<double> point in listePointLigne.coordinates[0])
            {
                string pointUn = point[0] + "";
                string pointZero = point[1] + "";

                if (compteur == 1)
                {
                    ar = "";
                    ar += pointZero.Replace(",", ".") + "," + pointUn.Replace(",", ".") + " ";
                    ar2 += pointZero.Replace(",", ".") + "," + pointUn.Replace(",", ".");
                    compteur = 2;
                    listAffichageTrace.Add(ar2);
                }
                else if (compteur == 0) {
                    ar = pointZero.Replace(",",".") + "," + pointUn.Replace(",", ".") + " ";
                    
                    compteur = 2;
                }
                else
                {
                    ar2 = "";
                    ar += pointZero.Replace(",", ".") + "," + pointUn.Replace(",", ".");
                    ar2 += pointZero.Replace(",", ".") + "," + pointUn.Replace(",", ".") + " ";
                    listAffichageTrace.Add(ar);
                    compteur = 1;
                }
                
            }

            ListeDesLignesAffichees = listAffichageTrace;



            return null;
        }

    }
}


