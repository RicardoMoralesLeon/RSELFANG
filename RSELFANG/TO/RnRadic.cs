using System;
using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class RnRadic
    {
        public int cen_codi { get; set; }    
        public string ter_coda{ get; set; } 
        public string rad_obse{ get; set; } 
        public string rad_dire{ get; set; } 
        public string rad_emai{ get; set; } 
        public string rad_tdat{ get; set; } 
        public int emp_codi{ get; set; }         
        public int tia_cont{ get; set; } 
        public int tia_codi{ get; set; } 
        public string tia_nomb{ get; set; } 
        public int tip_coda{ get; set; } 
        public string tip_nomb{ get; set; } 
        public string apo_coda{ get; set; } 
        public string apo_razs{ get; set; }         
        public int gru_cont{ get; set; } 
        public string gru_codi{ get; set; } 
        public string gru_nomb{ get; set; } 
        public int cra_cont{ get; set; } 
        public int cra_codi{ get; set; } 
        public string cra_nomb{ get; set; } 
        public string dsu_tele{ get; set; } 
        public int tip_codi{ get; set; } 
        public string tip_noma{ get; set; } 
        public string afi_docu{ get; set; } 
        public string afi_nom1{ get; set; } 
        public string afi_nom2{ get; set; } 
        public string afi_ape1{ get; set; } 
        public string afi_ape2{ get; set; } 
        public DateTime afi_fecn{ get; set; } 
        public string  afi_tele{ get; set; } 
        public string rad_pais{ get; set; } 
        public string rad_regi{ get; set; } 
        public string rad_depa{ get; set; } 
        public string rad_muni{ get; set; } 
        public string rad_loca{ get; set; } 
        public string rad_barr{ get; set; } 
        public int rad_nfol{ get; set; } 
        public List<RnDperc> rndperc{ get; set; } 
        public List<Rnradtd> radtdat{ get; set; }
        public List<RnAfili> rnafili { get; set; }
    }
}