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
            DAOSfForpo daoSfForpo = new DAOSfForpo();
            
            try
            {
                SfFovis fovis = new SfFovis();
                fovis.par_feab = daoSfForpo.GetSfParam(emp_codi);
                fovis.sfmodvi = daoSfForpo.GetModVi(emp_codi);
                
                return new TOTransaction<SfFovis>() { objTransaction = fovis, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<SfFovis>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}