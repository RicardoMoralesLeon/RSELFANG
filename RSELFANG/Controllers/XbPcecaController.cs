using DigitalWare.Apps.Utilities.Xb.TO;
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
    public class XbPcecaController : ApiController
    {
        // GET: api/XbPceca
        public TOTransaction<Xb_Pceca> GetXbPeca(short emp_codi)
        {
            return new BOXbPceca().GetXbPeca(emp_codi);
        }

        
    }
}
