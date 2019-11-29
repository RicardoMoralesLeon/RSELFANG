using Digitalware.Apps.Utilities.Fa.TO;
using RSELFANG.BO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class FaClienController : ApiController
    {
        // GET: api/FaClien
        public SevenFramework.TO.TOTransaction<FaClien> Get(short emp_codi, string cli_coda)
        {
            return new BOFaclien().GetFaclien(emp_codi, cli_coda);
        }
            
    }
}
