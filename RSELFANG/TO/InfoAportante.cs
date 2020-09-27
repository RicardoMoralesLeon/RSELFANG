using System;
using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class InfoAportante
    {
        public int dfo_cont { get; set; }
        public string ite_tipp { get; set; }
        public string ite_ocup { get; set; }
        public int for_sala { get; set; }
        public string for_cond { get; set; }        
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
       
        public string ite_codi_tp { get; set; }
        public string ite_nomb_tp { get; set; }
        public string ite_codi { get; set; }
        public string ite_nomb { get; set; }
        public int tco_codi { get; set; }
        public string tco_nomb { get; set; }
        public string tco_zona { get; set; }
        public double for_ipil { get; set; }
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
        
        public double for_ting { get; set; }
        public int for_nmie { get; set; }
        public double for_apr { get; set; }
        public int afi_edad { get; set; }
        public string afi_cond { get; set; }
        public string mpa_codi { get; set; }
        public string mpa_nomb { get; set; }
        public int apo_cont { get; set; }
        public string apo_razs { get; set; }
        public int ite_pare { get; set; }
        public double for_tapr { get; set; }
        
        public InfoAportante()
        {
            this.for_ting = 0;
        }
    }

    public class InfoEmpresa
    {
        public string apo_coda { get; set; }
        public string apo_razs { get; set; }
        public string tia_codi { get; set; }
        public string tia_nomb { get; set; }
        public string dep_codi { get; set; }
        public string dep_nomb { get; set; }
        public string mun_codi { get; set; }
        public string mun_nomb { get; set; }
        public string dsu_dire { get; set; }
        public string tra_prin { get; set; }

        public InfoEmpresa() {
            apo_coda = "";
            apo_razs = "";
            tia_codi = "";
            tia_nomb = "";
            dep_codi = "";
            dep_nomb = "";
            mun_codi = "";
            mun_nomb = "";
            dsu_dire = "";
            tra_prin = "";
        }
    }

    public class InfoNovedades
    {
        public int top_codi { get; set; }
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
        public int ite_pare { get; set; }
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
        public string mpa_codi { get; set; }
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

    public class InfoDfoih
    {
        public int for_cont { get; set; }
        public int dmo_rsmd { get; set; }
        public int dmo_rsmh { get; set; }
        public decimal dmo_fsvs { get; set; }
        public int dfo_vsol { get; set; }
        public string pai_codi { get; set; }
        public string reg_codi { get; set; }
        public string dep_codi  { get; set; }
        public string dep_nomb  { get; set; }
        public string mun_codi  { get; set; }
        public string mun_nomb  { get; set; }
        public string bar_codi  { get; set; }
        public string bar_nomb  { get; set; }
        public string loc_codi { get; set; }
        public string dfo_dire { get; set; }
        public string dfo_tele { get; set; }
        public int dfo_nitc { get; set; }
        public DateTime dfo_fesc { get; set; }
        public string dfo_matr { get; set; }
        public string dfo_escr { get; set; }
        public string dfo_lurb { get; set; }
        public string dfo_nomc { get; set; }
        public string dfo_nomp { get; set; }
        public int dfo_vpre { get; set; }
        public int dfo_vlot { get; set; }
        public int dfo_vtvi { get; set; }
        public int dfo_tota { get; set; }
        public int for_ting { get; set; }
        public int for_nmie { get; set; }
        public string mod_cspm { get; set; }
        public string tco_zona { get; set; }

        public InfoDfoih()
        {
            this.mod_cspm = "";
            this.dfo_lurb = "N";
        }
    }

    public class Gnmasal
    {
        public double mas_vrsm { get; set; }
        public double mas_vrsi { get; set; }
    }

    public class rnradic
    {
        public int rad_cont { get; set; }
        public string afi_docu { get; set; }
        public string rad_esta { get; set; }
        public string cra_dest { get; set; }
        public int afi_cont { get; set; }
    }

    public class InfoHogar
    {
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

        public string dfo_dire { get; set; }
        public string dfo_tele { get; set; }
        public double dfo_vsol { get; set; }
        public double dfo_vpre { get; set; }
        public double dfo_vlot { get; set; }
        public double dfo_vtvi { get; set; }
        public DateTime dfo_fesc { get; set; }
        public string dfo_matr { get; set; }
        public string dfo_escr { get; set; }
        public string dfo_lurb { get; set; }
        public int dfo_nitc { get; set; }
        public string dfo_nomc { get; set; }
        public string dfo_nomp { get; set; }
    }

    public class SfDfore
    {
        public int dfo_cont { get; set; }
        public string dfo_tipo { get; set; }
        public double dfo_sald { get; set; }
        public int con_cont { get; set; }
        public int con_codi { get; set; }
        public string con_nomb { get; set; }
        public List<SfDdfor> Infoddfor { get; set; }
    }

    public class SfDdfor
    {
        public int dfo_cont { get; set; }
        public string dfo_tipo { get; set; }
        public int con_codi { get; set; }
        public string ddf_entc { get; set; }
        public string ddf_entd { get; set; }
        public string ddf_numc { get; set; }
        public DateTime ddf_feca { get; set; }
        public DateTime ddf_feci { get; set; }
        public DateTime ddf_fecc { get; set; }
    }
}