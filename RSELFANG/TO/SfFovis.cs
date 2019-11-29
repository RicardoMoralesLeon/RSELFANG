using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class SfModvi
    {
        public int MOD_CONT { get; set; }
        public string MOD_NOMB { get; set; }
    }

    public class SfFovis
    {
        public string par_feab { get; set; }
        public List<SfModvi> sfmodvi { get; set; }

    }
}