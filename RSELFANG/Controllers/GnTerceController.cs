using RSELFANG.BO;
using RSELFANG.TO;
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
    public class GnTerceController : ApiController
    {
        // GET: api/GnTerce
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public SevenFramework.TO.TOTransaction<Gn_Terce> Get(string usu_codi)
        {
            BOGnTerce bo = new BOGnTerce();
            return bo.GetGnTerce(usu_codi);
        }

        // GET: api/GnTerce/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GnTerce
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GnTerce/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GnTerce/5
        public void Delete(int id)
        {
        }
    }
}
