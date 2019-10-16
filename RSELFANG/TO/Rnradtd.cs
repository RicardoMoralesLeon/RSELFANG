using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.TO
{
    public class Rnradtd
    {
        public string ite_nomb { get; set; }
        public string ite_codi { get; set; }
        public int ite_cont { get; set; }
        public bool ite_chkd { get; set; }

        public Rnradtd()
        {
            ite_chkd = false;
        }
    }
}