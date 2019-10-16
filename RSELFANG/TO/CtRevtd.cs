using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class CtRevtd
    {
        
        public string ite_nomb { get; set; }
        public string ite_codi { get; set; }
        public int ite_cont { get; set; }
        public bool ite_chkd { get; set; }

        public CtRevtd()
        {
            ite_chkd = false;
        }
    }    

    public class myObject
    {
        public int rev_cont { get; set; }
        public int emp_codi { get; set; }
        public  List<CtRevtd> detail { get; set; }
    }
}