
using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class RnDperc
    {
        public string dpe_docu { get; set; }
        public string dpe_nom1 {get; set; }
        public string dpe_nom2 {get; set; }
        public string dpe_ape1 {get; set; }
        public string dpe_ape2 {get; set; }        
        public string mpa_codi { get; set; }        
        public int ddo_cont { get; set; }
        public string ddo_ndoc { get; set; }
        public bool ddo_esis { get; set; }
        public bool ddo_recb { get; set; }
        public string ddo_obse { get; set; }
        public string ite_codi { get; set; }
        public List<RnDdocu> lst_ddoc { get; set; }
    }
}