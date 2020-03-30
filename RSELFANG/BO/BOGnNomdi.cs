using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RSELFANG.BO
{
    public class BOGnNomdi
    {
        public TOTransaction<List<GnNomdi>> GetGnNomdi()
        {
            DAOGnNomdi daoNomdi = new DAOGnNomdi();

            try
            {
                List<GnNomdi> Nomdi = daoNomdi.GetGnNomdi();
                return new TOTransaction<List<GnNomdi>>() { objTransaction = Nomdi, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<GnNomdi>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}