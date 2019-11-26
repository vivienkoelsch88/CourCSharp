using ConsoleApp2;
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

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindowC : Window
    {
        public GreetingViewModel viewModel;
        public ArrayJson Idtest { get; set; }

        public MainWindowC()
        {
            InitializeComponent();
            this.viewModel = new GreetingViewModel();
            this.DataContext = this.viewModel;
            this.Idtest = new ArrayJson
            {
                id = "JE TEEEEEST",
               
                
            };

        }

        private void Btn1_Click_1(object sender, RoutedEventArgs e)
        {
            this.viewModel.remplirArrets(tbSettingTextLat.Text, tbSettingTextLon.Text, tbSettingTextDist.Text);

              /*
            UtilApi api = new UtilApi(tbSettingTextLat.Text, tbSettingTextLon.Text);
            Dictionary<string, List<ArrayJson>> dictionnaireArret = api.getListLigne(int.Parse(tbSettingTextDist.Text));

          
            String Affiche = "";

            foreach (KeyValuePair<string, List<ArrayJson>> element in dictionnaireArret)
            {
                Affiche += "====================================" + "\n";
                Affiche += element.Key + "\n"; 
                Affiche += "====================================" + "\n"; 
               
                foreach (ArrayJson p in element.Value)
                {
                    foreach (String ligne in p.lines)
                    {
                        Affiche += ligne + "\n"; 
                        Affiche += "                                  ----------------                  " + "\n"; 
                    }
                }
            }
            listeArretBox.Text = Affiche;
            */
        }

        private void TbSettingTextLat_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TbSettingTextLon_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TbSettingTextDist_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
