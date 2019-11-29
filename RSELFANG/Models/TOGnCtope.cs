using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.Models
{
    [SevenFramework.DataBase.TableName("GN_CTOPE")]
    public class TOGnCtope
    {
      
        public short emp_codi { get; set; }
        public short top_codi { get; set; }
        public int cue_cont { get; set; }
        public string cue_codi { get; set; }
    }
}