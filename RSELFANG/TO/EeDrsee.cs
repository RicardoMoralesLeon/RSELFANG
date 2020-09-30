using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class EeDrsee
    {
        public EeDrsee()
        {
            Respuestas = new List<EeDdprc>();
        }

        public int res_cont { get; set; }
        public string res_valo { get; set; }
        public string drs_preg { get; set; }
        public string drs_clas { get; set; }
        public int sec_cont { get; set; }
        public int drs_orde { get; set; }        
        public int rse_cont { get; set; }
        public int drs_cont { get; set; }
        public int drp_cont { get; set; }
        public List<EeDdprc> Respuestas { get; set; }
    }
}