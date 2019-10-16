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
        public TOTransaction<List<Xb_Auliq>> Get(short emp_codi, string cli_coda)
        {
            return new BOXbAuliq().GetAutLiq(emp_codi, cli_coda);
        }

        // GET: api/XbBauliq/5
        
    }
}
