
using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class EeDrele
    {
        public EeDrele()
        {
            Preguntas = new List<EeDrsee>();            
        }
                
        public int dre_secc { get; set; }
        public string sec_nomb { get; set; }
        public List<EeDrsee> Preguntas { get; set; }       
    }
}