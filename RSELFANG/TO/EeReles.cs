﻿using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class EeReles
    {
        public EeReles() {
            Secciones = new List<EeDrele>();
        }

        public string par_rein { get; set; }
        public string red_encu { get; set; }
        public int num_preg { get; set; }
        public int rel_cont { get; set; }
        public string rel_nomb { get; set; }
        public List<EeDrele> Secciones { get; set; }
    }
}