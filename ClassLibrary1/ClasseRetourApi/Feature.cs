using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ClasseRetourApi
{
    public class Feature
    {
        public string type { get; set; }
        public GeometryV geometry { get; set; }
        public Properties properties { get; set; }
    }
}
