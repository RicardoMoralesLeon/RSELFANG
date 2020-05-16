using DigitalWare.Apps.Utilities.Gn.DAO;
using DigitalWare.Apps.Utilities.Gn.TO;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class GnModulController : ApiController
    {
        // GET: api/GnModul
        public TOTransaction<Gn_Modul> GetGnModul(int mod_codi )
        {
            try
            {
                var modul = DAO_Gn_Modul.GetGnModul(mod_codi);
                return new TOTransaction<Gn_Modul>() { ObjTransaction = modul, Retorno = 0, TxtError = "" };                
            }
            catch (Exception ex)
            {
                return new TOTransaction<Gn_Modul>() { ObjTransaction = null, Retorno = 1, TxtError = ex.Message };
            }
        }
      
    }
}
