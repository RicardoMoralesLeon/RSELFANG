using System;
using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class Suafili
    {
        public int afi_cont { get; set; }
        public string tip_codi { get; set; }
        public string afi_docu { get; set; }
        public string afi_nom1 { get; set; }
        public string afi_nom2 { get; set; }
        public string afi_ape1 { get; set; }
        public string afi_ape2 { get; set; }
        public List<Sfforpo> sfforpo { get; set; }
    }


    public class Sfforpo
    {
        public int for_nume { get; set; }
        public string for_fech { get; set; }
        public string for_fasi { get; set; }
        public string for_esta { get; set; }
        public int dfo_vsol { get; set; }
    }
}