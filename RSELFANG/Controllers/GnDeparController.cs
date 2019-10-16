using RSELFANG.BO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class GnDeparController : ApiController
    {
       /// <summary>
       /// Retorna la lista de departamentos para colombia (Pai_codi=169)
       /// </summary>
       /// <returns></returns>
        public List<GnDepar> Get()
        {
            BOGnDepar bo = new BOGnDepar();
            return bo.GetGnDepar(169);
        }

    }
}
