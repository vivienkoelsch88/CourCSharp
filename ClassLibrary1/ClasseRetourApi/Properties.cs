using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ClasseRetourApi
{
    public class Properties
    {
        public string NUMERO { get; set; }
        public string CODE { get; set; }
        public string COULEUR { get; set; }
        public string COULEUR_TEXTE { get; set; }
        public int PMR { get; set; }
        public string LIBELLE { get; set; }
        public List<string> ZONES_ARRET { get; set; }
        public string type { get; set; }
        public string id { get; set; }
    }
}
