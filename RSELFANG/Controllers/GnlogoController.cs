using RSELFANG.BO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RSELFANG.Controllers
{
    public class GnlogoController : ApiController
    {
        //// GET: api/Gnlogo
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        public TOTransaction<Gnlogo> Get(int emp_codi)
        {
            BOGnLogo bo = new BOGnLogo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetGnLogo(emp_codi);
        }
             
    }
}
