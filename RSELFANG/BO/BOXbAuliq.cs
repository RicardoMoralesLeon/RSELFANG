using RSELFANG.DAO;
using RSELFANG.TO;
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
                return new TOTransaction<List<Xb_Auliq>>() { objTransaction = result, retorno = 0, txtRetorno = "" };

            }
            catch (Exception ex)
            {

                return new TOTransaction<List<Xb_Auliq>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}