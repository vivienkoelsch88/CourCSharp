using ConsoleApp2.RequestApi.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConsoleApp2
{
    public class UtilApi : INotifyPropertyChanged
    {
        private IAppelsApi appelsApi;
        private String x;
        private String y;

        public event PropertyChangedEventHandler PropertyChanged;

        public UtilApi(String x, String y)
            : this(new AppelsApi(), x, y)
        {

        }

        internal UtilApi(IAppelsApi api, String x, String y)
        {
            this.appelsApi = api;
            this.x = x;
            this.y = y;
        }

        public UtilApi()
            : this(new AppelsApi(), "5.727718", "45.185603")
        {

        }

        public Dictionary<string, List<ArrayJson>> getListLigne(int rayon)
        {
            List<ArrayJson> liste = JsonConvert.DeserializeObject<List<ArrayJson>>(this.appelsApi.getRequest("http://data.metromobilite.fr/api/linesNear/json?x=" + x + "&y=" + y + "&dist=" + rayon + "&details=true"));

            Dictionary<string, List<ArrayJson>> listedef = new Dictionary<string, List<ArrayJson>>();

            foreach (ArrayJson ligne in liste) 
            {
                if (listedef.ContainsKey(ligne.name)) {
                    foreach (KeyValuePair<string, List<ArrayJson>> arret in listedef)
                    {
                        if (arret.Key == ligne.name)
                        {
                            arret.Value.Add(ligne);
                        }
                    }
                } else {
                    List<ArrayJson> ligneListDef = new List<ArrayJson>();
                    ligneListDef.Add(ligne);
                    listedef.Add(ligne.name, ligneListDef);
                }


            }
            return listedef;
        }

        public String getLigneInfos(String id)
        {
            List<InfoArret> infos = JsonConvert.DeserializeObject<List<InfoArret>>(this.appelsApi.getRequest("http://data.metromobilite.fr/api/routers/default/index/routes?codes=" + id));
            InfoArret info = infos[0];
            String affiche = "ligne " + info.longName + " ------- Mode : " + info.mode + " ------ Type : " + info.type;
            return affiche;
        }

        public bool SetProperty(ref List<ArrayJson> arrets, List<ArrayJson> value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(arrets, value)) return false;
            arrets = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
