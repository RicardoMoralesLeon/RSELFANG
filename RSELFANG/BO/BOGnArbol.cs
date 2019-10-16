using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOGnArbol
    {        
        public TOTransaction<List<GnArbol>> GetGbnArbol(string tar_codi,string arb_codi,int emp_codi)
        {
            try
            {               
                DAOGnArbol dao = new DAOGnArbol();
                List<GnArbol> result = new List<GnArbol>();
                result = dao.GetGnArbol(tar_codi, arb_codi, emp_codi);
                if (result == null || !result.Any())
                    throw new Exception(string.Format("No se encontraron arboles parametrizados para tar_codi {0} y arb_codi {1}",tar_codi,arb_codi));
                return new TOTransaction<List<GnArbol>>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch(Exception ex)
            {
                return new TOTransaction<List<GnArbol>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public List<GnArbol> GetGbnArbol(int tar_codi, int emp_codi)
        {
            DAOGnArbol dao = new DAOGnArbol();
            List<GnArbol> result = new List<GnArbol>();
            result = dao.GetGnArbol(tar_codi, emp_codi);
            if (result == null || !result.Any())
                throw new Exception("No se encontraron arboles parametrizados para el TAR_CODI = " + tar_codi);

            return result;
        }
    }
}