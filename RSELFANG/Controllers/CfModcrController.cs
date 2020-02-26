using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SevenFramework.TO;
using Digitalware.Apps.Utilities.Cf.Models;
using RSELFANG.BO;

namespace RSELFANG.Controllers
{
    public class CfModcrController : ApiController
    {
        // GET: api/CfModcr
        public TOTransaction<List<Cf_Modcr>> Get(int emp_codi)
        {
            return new BOCfModcr().GetList(emp_codi);
        }

        
    }
}
