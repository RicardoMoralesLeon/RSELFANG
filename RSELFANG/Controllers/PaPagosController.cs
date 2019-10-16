using RSELFANG.DAO;
using RSELFANG.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RSELFANG.Controllers
{
    public class PaPagosController : ApiController
    {
        string emp_codi = "";
     
        // GET: api/PaPagos
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Get()
        {
            emp_codi = ConfigurationManager.AppSettings["emp_codi"];
            if (string.IsNullOrEmpty(emp_codi))
                throw new Exception("Código de empresa no parametrizado en api");
            DAOTsParam dao = new DAOTsParam();
            TOTsParam param = dao.getTsParam(int.Parse(emp_codi));
            if (param == null)
                throw new Exception("Parámetros de tesorería no definidos");        
            if (string.IsNullOrEmpty(param.par_urss))
                return "1";
            return param.par_urss;
        }

        // GET: api/PaPagos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PaPagos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PaPagos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PaPagos/5
        public void Delete(int id)
        {
        }
    }
}
