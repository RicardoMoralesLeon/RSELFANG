using DigitalWare.Apps.Utilities.Gn.DAO;
using DigitalWare.Apps.Utilities.Gn.TO;
using RSELFANG.BO;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RSELFANG.Controllers
{
    public class GnItemsController : ApiController
    {
        /// <summary>
        /// Retorna una lista de items para el titem especificado
        /// </summary>
        /// <param name="tit_cont"></param>
        /// <param name="ite_codi"></param>
        /// <returns></returns>
        
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public TOTransaction<List<Gn_Items>> Get(int tit_cont)
        {
            BOGnItems bo = new BOGnItems();
            try
            {
                return new TOTransaction<List<Gn_Items>>() { ObjTransaction = DAO_Gn_Items.GetGnItems(0, tit_cont, ""), Retorno = 0, TxtError = "" };
            }
            catch (Exception ex)
            {

                return new TOTransaction<List<Gn_Items>>() { ObjTransaction = null, TxtError = ex.Message, Retorno = 1 };
            }
           
        }

       
    }
}
