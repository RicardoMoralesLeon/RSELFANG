using Digitalware.Apps.Utilities.Fa.TO;
using RSELFANG.BO;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class FaDdinaController : ApiController
    {
       public TOTransaction<List<Fa_Dina>> GetFaddina(short emp_codi, string cli_coda)
        {
            return new BOFaDdina().GetFaDina(emp_codi, cli_coda);
        }
    }
}
