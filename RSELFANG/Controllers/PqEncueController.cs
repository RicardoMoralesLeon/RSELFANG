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
    public class PqEncueController : ApiController
    {
      
        BOPqEncue boEncue = new BOPqEncue();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public TOTransaction Post(List<PQEncue> encuesta)
        {           
             return boEncue.SetPqEncue(encuesta);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public TOTransaction Get(int inp_cont,int emp_codi)
        {
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return boEncue.GetPqncue(inp_cont,emp_codi);
        }
    }
}
