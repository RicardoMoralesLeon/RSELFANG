using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class toArApovoInfo
    {
        public int apo_cont { get; set; }
        public string apo_coda { get; set; }
        public string apo_razs { get; set; }
        public string apo_fcha { get; set; }
        public string tip_abre { get; set; }
        public string tip_abrr { get; set; }
        public string ter_coda { get; set; }
        public string ter_noco { get; set; }
        public List<toArSucurInfo> arsucurinfo { get; set; }
    }

    public class toArSucurInfo
    {
        public string tip_desc { get; set; }
        public string dsu_dire { get; set; }
        public string pai_nomb { get; set; }
        public string dep_nomb { get; set; }
        public string mun_nomb { get; set; }
        public string loc_nomb { get; set; }
        public string bar_nomb { get; set; }
        public string dsu_tele { get; set; }
        public string dsu_celu { get; set; }
    }

    //public class tofiliatrab
    //{
    //    public int afi_cont { get; set; }
    //    public string tip_abre { get; set; }
    //    public string afi_docu { get; set; }
    //    public string afi_fecn { get; set; }
    //    public string afi_noco { get; set; }
    //    public string afi_nom1 { get; set; }
    //    public string afi_nom2 { get; set; }
    //    public string afi_ape1 { get; set; }
    //    public string afi_ape2 { get; set; }
    //    public string afi_dire { get; set; }
    //    public string afi_tele { get; set; }
    //    public string afi_celu { get; set; }
    //    public string pai_nomb { get; set; }
    //    public string dep_nomb { get; set; }
    //    public string mun_nomb { get; set; }
    //    public string loc_nomb { get; set; }
    //    public string bar_nomb { get; set; }
    //    public List<toSuperca> superca { get; set; }
    //}

    //public class toSuperca
    //{
    //    public string tip_abre { get; set; }
    //    public string afi_docu { get; set; }
    //    public string afi_fecn { get; set; }
    //    public string afi_noco { get; set; }
    //    public string afi_nom1 { get; set; }
    //    public string afi_nom2 { get; set; }
    //    public string afi_ape1 { get; set; }
    //    public string afi_ape2 { get; set; }
    //    public string mpa_nomb { get; set; }
    //    public string rad_fech { get; set; }
    //}

    //public class toRnRadic
    //{
    //    public int rad_nume { get; set; }
    //    public string rad_fech { get; set; }
    //    public string cra_nomb { get; set; }
    //    public string rad_esta { get; set; }
    //    public string rad_fecc { get; set; }
    //}
}