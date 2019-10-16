using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.Models
{
    public class TOEcDespa
    {
        public string emp_codi { get; set; }
        public string cot_cont { get; set; }
        public int    des_cont { get; set; }
        public DateTime des_fing { get; set; }
        public string des_ndia { get; set; }
        public DateTime des_fsal { get; set; }
        public string esp_cont { get; set; }
        public string des_capa { get; set; }
        public string ter_codi { get; set; }
        public string tip_codi { get; set; }
        public string des_dinv { get; set; }
        public string des_ninv { get; set; }
        public string pro_cont { get; set; }
        public string des_tari { get; set; }
        public string des_tdes { get; set; }
        public string des_vdes { get; set; }
        public string des_care { get; set; }
        public string res_cont { get; set; }
        public string esp_codi { get; set; }
        public string esp_nomb { get; set; }
        public string cla_cont { get; set; }
        public string cla_codi { get; set; }
        public string cla_nomb { get; set; }
        public string cla_clti { get; set; }
        public string lip_cont { get; set; }
        public string tip_cont_e { get; set; }
        public string tip_codi_e { get; set; }
        public string tip_nomb_e { get; set; }
        public string ter_coda { get; set; }
        public string ter_noco { get; set; }
        public string tip_abre { get; set; }
        public string pro_codi { get; set; }
        public string pro_nomb { get; set; }
        public string bod_codi { get; set; }
        public string res_fech { get; set; }
        public string res_fini { get; set; }
        public string esp_mdit { get; set; }
        public List<TOEcDphij> productos { get; set; }
        public TOAeClase clase { get; set; }
    }
}