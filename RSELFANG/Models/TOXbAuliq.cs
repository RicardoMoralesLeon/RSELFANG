using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.Models
{
    public class TOXbAuliq
    {
       public TOXbAuliq()
        {
            error = "";
            cxc_bgrav = 0;
        }

        public int cxc_cont { get; set; }
        public long ite_ctse { get; set; }      
        public string cts_nomb { get; set; }
        public int rcx_vige { get; set; }
        public int top_codi { get; set; }
        public string top_nomb { get; set; }
        public string cxc_desc{ get; set; }
        public decimal cxc_tota { get; set; }
        public decimal cxc_sald { get; set; }
        public decimal dpa_tari { get; set; }
        public DateTime par_fech { get; set; }
        public decimal cxc_inmo { get; set; }
        public decimal cxc_inan { get; set; }
        public DateTime cxc_feve { get; set; }
        public bool liq_apro { get; set; }
        public string error { get; set; }
        [SevenFramework.DataBase.NotMapped]
        public bool liq_lock { get; set; }
        public int dcl_codd { get; set; }
        public int emp_codi { get; set; }
        public decimal cxc_bgrav { get; set; }




    }
    public class Xb_AutliqP
    {
        public short emp_codi { get; set; }
        public string usu_codi { get; set; }
        public string cli_coda { get; set; }   
        public DateTime par_fech { get; set; }
        public List<TOXbAuliq> cuentas { get; set; }
    }
}