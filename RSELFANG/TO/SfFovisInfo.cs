using System;

namespace RSELFANG.TO
{
    public class SfFovisInfo
    {
        public int MOD_CONT { get; set; }
        public string MOD_NOMB{ get; set; }
        public int TCO_CODI{ get; set; }
        public string TCO_NOMB{ get; set; }
        public string MOD_CSPM { get; set; }
        public string TCO_ZONA { get; set; }
    }

    public class SfRadic
    {
        public int EMP_CODI { get; set; }
        public int RAD_NUME { get; set; }
        public DateTime RAD_FECH { get; set; }
        public int TIP_CODI { get; set; }
        public string AFI_DOCU { get; set; }
        public string AFI_NOM1 { get; set; }
        public string AFI_NOM2 { get; set; }
        public string AFI_APE1 { get; set; }
        public string AFI_APE2 { get; set; }
        public int FOR_CONT { get; set; }
    }

    public class SfPostu
    {
        public int EMP_CODI { get; set; }
        public int TIP_CODI { get; set; }
        public string TIP_NOMB { get; set; }
        public string AFI_DOCU { get; set; }
        public string AFI_NOM1 { get; set; }
        public string AFI_NOM2 { get; set; }
        public string AFI_APE1 { get; set; }
        public string AFI_APE2 { get; set; }
        public int AFI_CONT { get; set; }
    }

    public class SfAfili
    {        
        public int TIP_CODI { get; set; }
        public string AFI_DOCU { get; set; }
        public string AFI_NOM1 { get; set; }
        public string AFI_NOM2 { get; set; }
        public string AFI_APE1 { get; set; }
        public string AFI_APE2 { get; set; }
        public DateTime AFI_FECN { get; set; }
        public string AFI_ESCI { get; set; }
        public string AFI_CATE { get; set; }
        public string AFI_GENE { get; set; }
        public string TIP_NOMB { get; set; }
        public int AFI_CONT { get; set; }
        public string AFI_COND { get; set; }
        public string AFI_MAIL { get; set; }
        public string AFI_TELE { get; set; }
        public string AFI_DIRE { get; set; }
        public int PAI_CODI { get; set; }
        public string PAI_NOMB { get; set; }
        public int REG_CODI { get; set; }
        public string REG_NOMB { get; set; }
        public int DEP_CODI { get; set; }
        public string DEP_NOMB { get; set; }
        public int MUN_CODI { get; set; }
        public string MUN_NOMB { get; set; }
        public int LOC_CODI { get; set; }
        public string LOC_NOMB { get; set; }
        public int BAR_CODI { get; set; }
        public string BAR_NOMB { get; set; }
        public int AFI_CONY { get; set; }
        public int ITE_CODI_OC { get; set; }
    }

    public class GnItems
    {
        public string ITE_NOMB { get; set; }
        public string ITE_CODI { get; set; }
        public int ITE_CONT { get; set; }
    }

    public class sfconec
    {
        public int CON_CONT { get; set; }
        public string CON_CODI { get; set; }
        public string CON_NOMB { get; set; }
    }

    public class sfforpo
    {
        public int for_cont { get; set; }
        public int for_nume { get; set; }
    }
}