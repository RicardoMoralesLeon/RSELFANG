using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.Models
{
    public class TOEcCotiz
    {
        public TOEcCotiz()
        {
            detalle = new List<TOEcDespa>();
            anticipos = new List<TOEcDetan>();
            liquidacion = new List<TOLiqCons>();
            invitados = new List<TOEcLisev>();
        }      
        public string emp_codi { get; set; }
        public int cot_cont { get; set; }
        public string top_codi { get; set; }
        public string cot_nume { get; set; }
        public DateTime cot_fech { get; set; }
        public string cot_nech { get; set; }
        public string cot_anop { get; set; }
        public string cot_mesp { get; set; }
        public string cot_diap { get; set; }
        public string cot_esta { get; set; }
        public string cas_cont { get; set; }
        public string cot_fvec { get; set; }
        public string cot_fing { get; set; }
        public string cot_ndia { get; set; }
        public string cot_fsal { get; set; }
        public string cot_nver { get; set; }
        public string soc_cont { get; set; }
        public string mac_nume { get; set; }
        public string sbe_cont { get; set; }
        public string cot_orga { get; set; }
        public string cot_norg { get; set; }
        public string cot_torg { get; set; }
        public string cot_coor { get; set; }
        public string cot_ncoo { get; set; }
        public string cot_tcoo { get; set; }
        public string ter_ejec { get; set; }
        public string ter_capi { get; set; }
        public string cot_mail { get; set; }
        public string cot_desc { get; set; }
        public string cot_obse { get; set; }
        public string cot_prot { get; set; }
        public string ite_cont { get; set; }
        public string cot_fpag { get; set; }
        public string cli_codi { get; set; }
        public string dcl_codd { get; set; }
        public string con_codi { get; set; }
        public string arb_sucu { get; set; }
        public string coc_codi { get; set; }
        public string act_cont { get; set; }
        public string mon_codi { get; set; }
        public string cot_feta { get; set; }
        public string cot_vata { get; set; }
        public string lip_cont { get; set; }
        public string for_codi { get; set; }
        public string cot_vato { get; set; }
        public string cot_gccl { get; set; }
        public string cot_ncon { get; set; }
        public string cot_plaz { get; set; }
        public string cot_upla { get; set; }
        public string cot_objc { get; set; }
        public string cot_dcre { get; set; }
        public string ite_mcan { get; set; }
        public string con_cont { get; set; }
        public int eve_cont { get; set; }
        public string cot_ecor { get; set; }
        public string top_nomb { get; set; }
        public string soc_codi { get; set; }
        public string sbe_codi { get; set; }
        public string sbe_noco { get; set; }
        public string sbe_ncar { get; set; }
        public string ter_coda_ej { get; set; }
        public string ter_noco_ej { get; set; }
        public string ter_coda_ca { get; set; }
        public string ter_noco_ca { get; set; }
        public string ite_codi { get; set; }
        public string ite_nomb { get; set; }
        public string cli_coda { get; set; }
        public string cli_noco { get; set; }
        public string dcl_nomb { get; set; }
        public string con_nomb { get; set; }
        public string arb_codi { get; set; }
        public string arb_nomb { get; set; }
        public string coc_nomb { get; set; }
        public string act_codi { get; set; }
        public string act_nomb { get; set; }
        public string mon_nomb { get; set; }
        public string lip_codi { get; set; }
        public string lip_desc { get; set; }
        public string for_nomb { get; set; }
        public string ite_codi_mc { get; set; }
        public string ite_nomb_mc { get; set; }

        public List<TOEcDespa> detalle { get; set; }
        public List<TOEcDetan>anticipos { get; set; }
        public List<TOLiqCons> liquidacion { get; set; }
        public List<TOEcLisev> invitados { get; set; }
        
    }
}