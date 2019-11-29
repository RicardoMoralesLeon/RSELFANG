using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;

namespace RSELFANG.BO
{
    public class BOSfForpo
    {
        public TOTransaction<SfFovis> GetInitialDataSf(int emp_codi)
        {            
            BOGnArbol boArbol = new BOGnArbol();
            DAOSfForpo sfparam = new DAOSfForpo();
            
            try
            {
                SfFovis result = new SfFovis();
                result.par_feab = sfparam.GetSfParam(emp_codi);
                return new TOTransaction<SfFovis>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<SfFovis>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}