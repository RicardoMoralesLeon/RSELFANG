using Digitalware.Apps.Utilities.Cf.DAO;
using Digitalware.Apps.Utilities.Cf.Models;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class CfTasasController : ApiController
    {
        // GET: api/CfTasas
        public TOTransaction<List<Cf_Tasas>> Get()
        {
            try
            {
                return new TOTransaction<List<Cf_Tasas>> { Retorno = 0, ObjTransaction = new DAO_Cf_Tasas().GetCfTasas(), TxtError = "" };
            }
            catch (Exception ex)
            {

                return new TOTransaction<List<Cf_Tasas>>() { ObjTransaction = null, Retorno = 1, TxtError = ex.Message };
            }
        }

        // GET: api/CfTasas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CfTasas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CfTasas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CfTasas/5
        public void Delete(int id)
        {
        }
    }
}
