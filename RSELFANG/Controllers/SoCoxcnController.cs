using RSELFANG.BO;
using RSELFANG.Models;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RSELFANG.Controllers
{
    public class SoCoxcnController : ApiController
    {
        // GET: api/SoCoxcn
        BOSoCoxcn bo = new BOSoCoxcn();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public TOTransaction< List<TOSoCocxn>> Get(string soc_codi,DateTime cox_fech)
        {
            return bo.getsocoxcn(soc_codi, cox_fech);
        }

        // GET: api/SoCoxcn/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SoCoxcn
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SoCoxcn/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SoCoxcn/5
        public void Delete(int id)
        {
        }
    }
}
