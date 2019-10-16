using RSELFANG.DAO;
using RSELFANG.Models;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOXbAuliq
    {
        public TOTransaction<List<Xb_Auliq>> GetAutLiq(short emp_codi, string cli_coda)
        {
            try
            {
                var result = new DAOCaCxcob().GetAuliquidacion(emp_codi, cli_coda);
                return new TOTransaction<List<Xb_Auliq>>() { ObjTransaction = result, Retorno = 0, TxtError = "" };

            }
            catch (Exception ex)
            {

                return new TOTransaction<List<Xb_Auliq>>() { ObjTransaction = null, Retorno = 1, TxtError = ex.Message };
            }
        }
    }
}