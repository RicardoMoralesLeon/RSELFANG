using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.Models
{
    public class TOCaCpcob
    {
        public int emp_codi { get; set; }
        public string cpc_cont { get; set; }
        public int cxc_orig { get; set; }
        public int cxc_dest { get; set; }
        public string cpc_esta { get; set; }
        public DateTime cxc_fupa { get; set; }
        public decimal cxc_sald { get; set; }
    }

    public class Ca_Cpcob
    {

        public string aud_esta { get; set; }
        public string aud_usua { get; set; }
        public DateTime aud_ufac { get; set; }
        public int emp_codi { get; set; }
        public int cpc_cont { get; set; }
        public int cxc_orig { get; set; }
        public int cxc_dest { get; set; }
        public string cpc_esta { get; set; }
        public int cpc_vige { get; set; }
        //public long cli_codi { get; set; }
        //public int dcl_codd { get; set; }
        //public int ite_ctse { get; set; }
    }
}