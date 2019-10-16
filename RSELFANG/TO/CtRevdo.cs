using System;

namespace RSELFANG.TO
{
    public class CtRevdo
    {
        public int doc_cont { get; set; }
        public int pro_nreg { get; set; }
        public string pro_ddoc { get; set; }
        public DateTime pro_fent { get; set; }
        public DateTime pro_fven { get; set; }
        public string pro_obse { get; set; }
        public string adj_nomb { get; set; }
        public string rev_apro { get; set; }
        public Boolean ite_chkd { get; set; }
        public string rad_llav { get; set; }
        public byte[] adj_file { get; set; }
    }
}