using RSELFANG.DAO;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class GnTipdoController : ApiController
    {
        // GET: api/GnTipdo
        public TOTransaction<List<RSELFANG.TO.GnTipdo>> Get()
        {
            try
            {
                return new TOTransaction<List<RSELFANG.TO.GnTipdo>> { ObjTransaction = new DAOGnTipdo().getListGnTipdo(), Retorno = 0, TxtError = "" };
            }
            catch (Exception ex)
            {

                return new TOTransaction<List<RSELFANG.TO.GnTipdo>>() { ObjTransaction = null, Retorno = 1, TxtError = string.Format("Error cargando lista de documentos: {0}",  ex.Message) };
            }
           
        }

        
    }
}
