using Digitalware.Apps.Utilities.Cr.BO;
using Digitalware.Apps.Utilities.Cr.Models;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class CrRtmclController : ApiController
    {
        // GET: api/CrRtmcl
        public TOTransaction<Cr_Rtmcl> Get(int emp_codi, int tas_cont, int mod_cont, int ite_cont)
        {
        
                return new BOCrRtmcl().Get(emp_codi, tas_cont, mod_cont, ite_cont);
          
        }
    }
}
