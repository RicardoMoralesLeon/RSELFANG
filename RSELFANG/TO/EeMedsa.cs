using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.TO
{
    public class EeMedsa
    {
        public int ite_codi { get; set; }
        public string dat_nomb { get; set; }
        public int cantidad { get; set; }
        public double porcentaje { get; set; }
    }

    public class EeSaSec
    {
        public int sec_cont { get; set; }
        public string sec_codi { get; set; }
        public string sec_nomb { get; set; }
        public string frecuencia { get; set; }
        public double calificacion { get; set; }
        public double satisfaccion { get; set; }
        public string interpretacion { get; set; }
    }

    public class EeDeSec
    {
        public int drs_cont { get; set; }
        public string drs_preg { get; set; }
        public string frecuencia { get; set; }
        public double calificacion { get; set; }
        public double satisfaccion { get; set; }
        public string interpretacion { get; set; }
    }

    public class EeSaSer
    {
        public string ser_codi { get; set; }
        public string ser_nomb { get; set; }
        public string frecuencia { get; set; }
        public double calificacion { get; set; }
        public double oportunidad { get; set; }
        public string interpretacion { get; set; }
    }
}