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
    public class FaInaclController : ApiController
    {
        // GET: api/FaInacl


        public TOTransaction<Fa_Inacl> GetFaInacl(short emp_codi,string cli_coda)
        {
            return new BOFaInacl().GetFaInacl(emp_codi, cli_coda);
        }
       
    }
}
