using System;

namespace RSELFANG.TO
{
    public class InfoAportante
    {
        public int for_cont { get; set; }
        public int for_nume { get; set; }
        public DateTime for_fech { get; set; }
        public string for_esta { get; set; }
        public DateTime for_fvig { get; set; }
        public DateTime for_fpro { get; set; }
        public string mod_cont { get; set; }
        public string for_insf { get; set; }
        public int rad_cont { get; set; }
        public DateTime for_fasi { get; set; }
        public string ite_tipp { get; set; }
        public string ite_ocup { get; set; }
        public int for_sala { get; set; }
        public string for_cond { get; set; }
        public int for_post { get; set; }
        public string mod_nomb { get; set; }
        public int tip_codi { get; set; }
        public int afi_cont { get; set; }
        public string afi_docu { get; set; }
        public string tip_nomb { get; set; }
        public string afi_nom1 { get; set; }
        public string afi_nom2 { get; set; }
        public string afi_ape1 { get; set; }
        public string afi_ape2 { get; set; }
        public string afi_fecn { get; set; }
        public string afi_esci { get; set; }
        public string afi_cate { get; set; }
        public string afi_dire { get; set; }
        public string afi_gene { get; set; }
        public int rad_nume { get; set; }
        public string ite_codi_tp { get; set; }
        public string ite_nomb_tp { get; set; }
        public string ite_codi_oc { get; set; }
        public string ite_nomb_oc { get; set; }
        public int tco_codi { get; set; }
        public string tco_nomb { get; set; }
        public string tco_zona { get; set; }
        public double afi_ipil { get; set; }
        public string bar_nomb { get; set; }
        public string loc_nomb { get; set; }
        public string mun_nomb { get; set; }
        public string dep_nomb { get; set; }
        public string reg_nomb { get; set; }
        public string pai_nomb { get; set; }
        public int pai_codi { get; set; }
        public int reg_codi { get; set; }
        public int dep_codi { get; set; }
        public int mun_codi { get; set; }
        public int loc_codi { get; set; }
        public int bar_codi { get; set; }
        public string afi_mail { get; set; }
        public string afi_tele { get; set; }
        public int afi_cony { get; set; }
        public string mod_cspm { get; set; }
        public string for_tdat { get; set; }
        public double for_ting { get; set; }
        public int for_nmie { get; set; }
        public double for_apr { get; set; }
        public int afi_edad { get; set; }
        public string afi_cond { get; set; }
    }
   
    public class InfoNovedades
    {
        public int top_codi { get; set;  }
        public string top_nomb { get; set; }
        public int ret_nume { get; set; }
        public DateTime ret_fech { get; set; }
        public string ret_desc { get; set; }
        public string ret_esta { get; set; }
        public string codigo { get; set; }
        public string programa { get; set; }
    }

    public class InfoTrayectoria
    {
        public int for_cont { get; set; }
        public string rad_cont { get; set; }        
        public DateTime dfo_fech { get; set; }
        public int rad_nume { get; set; }
        public DateTime rad_fech { get; set; }
        public int cra_codi { get; set; }
        public string cra_nomb { get; set; }
        public int secuencia { get; set; }
    }

    public class InfoSuPerca
    {
        public int for_cont { get; set; }
        public int dfo_cont { get; set; }
        public int afi_cont { get; set; }
        public string dfo_tipo { get; set; }
        public string dfo_docu { get; set; }
        public string dfo_nom1 { get; set; }
        public string dfo_nom2 { get; set; }
        public string dfo_ape1 { get; set; }
        public string dfo_ape2 { get; set; }
        public string mpa_nomb { get; set; }        
        public DateTime dfo_fecn { get; set; }
        public string dfo_esci { get; set; }
        public string dfo_gene { get; set; }
        public string dfo_cond { get; set; }
        public double dfo_sala { get; set; }
        public double dfo_ipil { get; set; }
        public string apo_razs { get; set; }
        public int ite_codi_tp { get; set; }
        public string ite_nomb_tp { get; set; }
        public int ite_codi_oc { get; set; }
        public string ite_nomb_oc { get; set; }
    }

    public class InfoOtrosMiembros
    {
        public int for_cont { get; set; }
        public int dfo_cont { get; set; }
        public int afi_cont { get; set; }
        public string dfo_tipo { get; set; }
        public string dfo_docu { get; set; }
        public string dfo_nom1 { get; set; }
        public string dfo_nom2 { get; set; }
        public string dfo_ape1 { get; set; }
        public string dfo_ape2 { get; set; }
        public string mpa_nomb { get; set; }
        public DateTime dfo_fecn { get; set; }
        public string dfo_esci { get; set; }
        public string dfo_gene { get; set; }
        public string dfo_cond { get; set; }
        public double dfo_sala { get; set; }
        public double dfo_ipil { get; set; }
        public string apo_razs { get; set; }
        public int ite_codi_tp { get; set; }
        public string ite_nomb_tp { get; set; }
        public int ite_codi_oc { get; set; }
        public string ite_nomb_oc { get; set; }
        public string ite_codi_pa { get; set; }
        public string ite_nomb_pa { get; set; }
    }

    public class sfmodvi
    {
        public int dmo_rsmd { get; set; }
        public int dmo_rsmh { get; set; }
        public decimal dmo_fsvs { get; set; }

        public sfmodvi()
        {
            dmo_rsmd = 0;
            dmo_rsmh = 0;
        }
    }

    public class gnmasal
    {
        public double mas_vrsm { get; set; }
        public double mas_vrsi { get; set; }
    }

    public class rnradic
    {
        public int rad_cont { get; set; }
        public string afi_docu  { get; set; }
        public string rad_esta { get; set; }
        public string cra_dest { get; set; }
        public int afi_cont { get; set; }
    }

}