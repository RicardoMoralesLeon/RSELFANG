
using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class tofiliatrab
    {
        public int afi_cont { get; set; }
        public int tip_codi { get; set; }
        public string tip_nomb { get; set; }
        public string tip_abre { get; set; }
        public string afi_docu { get; set; }
        public string afi_fecn { get; set; }
        public string afi_noco { get; set; }
        public string afi_nom1 { get; set; }
        public string afi_nom2 { get; set; }
        public string afi_ape1 { get; set; }
        public string afi_ape2 { get; set; }
        public string afi_dire { get; set; }
        public string afi_tele { get; set; }
        public string afi_celu { get; set; }
        public string pai_nomb { get; set; }
        public string dep_nomb { get; set; }
        public string mun_nomb { get; set; }
        public string loc_nomb { get; set; }
        public string bar_nomb { get; set; }   
        public List<toSutraye> sutraye { get; set; }
        public List<toSuperca> superca { get; set; }
    }

    public class toSutraye
    {
        public string tip_abre { get; set; }
        public string apo_coda { get; set; }
        public string apo_razs { get; set; }
        public string tra_fchi { get; set; }
        public string tra_fcha { get; set; }
    }

    public class toSuperca
    {
        public string tip_abre { get; set; }
        public string afi_docu { get; set; }
        public string afi_fecn { get; set; }
        public string afi_noco { get; set; }
        public string afi_nom1 { get; set; }
        public string afi_nom2 { get; set; }
        public string afi_ape1 { get; set; }
        public string afi_ape2 { get; set; }
        public string mpa_nomb { get; set; }
        public string rad_fech { get; set; }
    }

    public class toRnRadic
    {
        public int rad_cont { get; set; }
        public int rad_nume { get; set; }
        public string rad_fech { get; set; }
        public string cra_nomb { get; set; }
        public string rad_esta { get; set; }
        public string rad_fecc { get; set; }
    }

    public class toArDpil
    {        
        public string apo_coda { get; set; }
        public string apo_razs { get; set; }
        public int rpi_peri { get; set; }
        public string rpi_nura { get; set; }
        public string rpi_fchp { get; set; }
        public double dri_sapb { get; set; }
        public double rpi_devo { get; set; }
        public double rpi_mora { get; set; }
        public double tot_apor { get; set; }
        public double dri_sibc { get; set; }
        public string afi_noco { get; set; }
        public string afi_nom1 { get; set; }
        public string afi_nom2 { get; set; }
        public string afi_ape1 { get; set; }
        public string afi_ape2 { get; set; }
    }
}
