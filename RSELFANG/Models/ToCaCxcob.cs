using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.Models
{
    public class ToCaCxcob
    {
        /// <summary>
        /// Total de la cuenta por cobrar
        /// </summary>
        public double cxc_tota { get; set; }
        public double cxc_sald { get; set; }
        public int tip_codi { get; set; }
        public string tip_nomb { get; set; }
    }
}