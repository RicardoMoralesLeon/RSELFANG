using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class PqTrazabilidadPqr
    {   
        public string inp_nomb { get; set; }
        public string inp_apel { get; set; }
        public string inp_nide { get; set; }
        public string inp_mail { get; set; }
        public string ite_nomb { get; set; }
        public string arb_nomb { get; set; }
        public string dpa_grup { get; set; }
        public string inp_esta { get; set; }
        public string inp_mpqr { get; set; }
        public List<PqDinPq> seguimientos { get; set; }
    }
}