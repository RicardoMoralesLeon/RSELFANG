using RSELFANG.BO;
using RSELFANG.Models;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class XbBauliqController : ApiController
    {
        // GET: api/XbBauliq
        public TOTransaction<List<TOXbAuliq>> Get(short emp_codi, string cli_coda,DateTime par_fech,int ite_ctse)
        {
            return new BOXbAuliq().GetAutLiq(emp_codi, cli_coda,par_fech,ite_ctse);
        }        
        public TOTransaction Post(Xb_AutliqP autoliquidacion)
        {
            return new BOXbAuliq().SetAutliq(autoliquidacion);      
        }

        [HttpPost]
        [Route("api/XbBauliq/BuildPrintLink")]
        public TOTransaction<string> BuildPrintLink(ToPrintLiq liquidacion)
        {
            return new BOXbAuliq().BuildPrintLink(liquidacion);
        }
        // GET: api/XbBauliq/5

    }
}
