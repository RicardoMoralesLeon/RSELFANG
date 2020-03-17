using Digitalware.Apps.Utilities.Cf.BO;
using Digitalware.Apps.Utilities.Cf.Models;
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
    public class CfScrevController : ApiController
    {

        [HttpPost]
        [Route("api/CfScrev")]
        public TOTransaction SetCfScrev(Cf_Screv credito)
        {
            return new RSELFANG.BO.BOCfScrev().SetCfScrev(credito);
        }
    }
}
