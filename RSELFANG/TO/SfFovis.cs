
using System.Collections.Generic;

namespace RSELFANG.TO
{  
    public class SfFovis
    {
        public double drp_salab { get; set; }
        public string par_feab { get; set; }
        public InfoAportante InfoAportante { get; set; }
        public InfoAportante InfoConyuge { get; set; }
        public List<InfoNovedades> InfoNovedades { get; set; }
        public List<InfoTrayectoria> InfoTrayectoria { get; set; }
        public List<InfoSuPerca> InfoSuPerca { get; set; }
        public List<InfoOtrosMiembros> InfoOtrosMiembros { get; set; }
        public sfmodvi InfoModvi { get; set; }
        public gnmasal  InfoGnmasal { get; set; }        
    }
}