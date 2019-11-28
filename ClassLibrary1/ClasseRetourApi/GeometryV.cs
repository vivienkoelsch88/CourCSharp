using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ClasseRetourApi
{
    public class GeometryV
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
    }
}
