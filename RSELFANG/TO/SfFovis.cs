
using System;

namespace RSELFANG.TO
{
    public class SfFovis
    {
        public int emp_codi { get; set; }
        public int for_cont { get; set; }
        public int for_nume { get; set; }
        public DateTime for_fech { get; set; }
        public string for_esta { get; set; }
        public DateTime for_fvig { get; set; }
        public DateTime for_fpro { get; set; }
        public string mod_cont { get; set; }
        public string for_insf { get; set; }
        public int rad_cont { get; set; }
        public int rad_nume { get; set; }
        public DateTime for_fasi { get; set; }
        public double drp_salab { get; set; }
        public string par_feab { get; set; }

        public InfoAportante InfoAportante { get; set; }
        public InfoAportante InfoConyuge { get; set; }
        public InfoEmpresa InfoEmpresa { get; set; }

        public sfdmodv InfoModvi { get; set; }
        public Gnmasal InfoGnmasal { get; set; }

        public SfFovis()
        {
            for_esta = "I";
            for_insf = "P";
        }
    }
}