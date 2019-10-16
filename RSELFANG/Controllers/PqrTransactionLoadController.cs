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
    public class PqrTransactionLoadController : ApiController
    {

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: api/PqrTransactionLoad
        public TOTransaction<PqrTransactionLoad> Get(string cli_coda, int emp_codi)
        {
            BOPqInpqr bo = new BOPqInpqr();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInitialDataWpqinqr(cli_coda,emp_codi);
        }

        public TOTransaction<List<GnItem>> Get(int emp_codi, int ite_cont)
        {
            BOPqInpqr bo = new BOPqInpqr();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoTipificacion(ite_cont);
        }

        public TOTransaction<GnFlag> Get(int emp_codi)
        {
            BOPqInpqr bo = new BOPqInpqr();            
            return bo.getInfoflgTipi();
        }
    }
}
