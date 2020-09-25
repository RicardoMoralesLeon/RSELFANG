
using System;
using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class SfFovis
    {
        public int emp_codi { get; set; }
        public int for_cont { get; set; }
        public int for_nume { get; set; }
        public string for_esta { get; set; }
        public string for_insf { get; set; }
        public string for_tdat { get; set; }
        public int mod_cont { get; set; }
        public string mod_nomb { get; set; }
        public int tco_codi { get; set; }
        public string tco_nomb { get; set; }
                
        public InfoDfoih infoHogar { get; set; }
        public InfoAportante postulante { get; set; }
        public InfoAportante conyuge { get; set; }
        public List<InfoEmpresa> InfoEmpresa { get; set; }
        public List<InfoAportante> InfoSfDfomhP { get; set; }
        public List<InfoAportante> InfoSfDfomhO { get; set; }
        public Gnmasal InfoGnmasal { get; set; }

        public List<SfDfore> Infodfore { get; set; }
        public List<SfDdfor> Infoddfor { get; set; }

    }
}