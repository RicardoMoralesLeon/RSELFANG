using Digitalware.Apps.Utilities.Su.BO;
using Digitalware.Apps.Utilities.Su.Models;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class SuAfiliController : ApiController
    {
        // GET: api/SuAfili
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SuAfili/5
        public TOTransaction<Su_Afili> Get(int emp_codi,string afi_docu)
        {
            return new BO_Su_Afili().GetSuAfili(emp_codi, afi_docu);
        }

        // POST: api/SuAfili
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SuAfili/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SuAfili/5
        public void Delete(int id)
        {
        }
    }
}
