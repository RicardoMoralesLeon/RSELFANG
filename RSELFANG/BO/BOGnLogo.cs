using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOGnLogo
    {

       
       public TOTransaction<Gnlogo> GetGnLogo(int emp_codi)
        {
            DAOGnLogo dao = new DAOGnLogo();
            try
            {              
                var result = dao.GetGnLogo(emp_codi);
                if (result == null)
                    throw new Exception("No se encontraron datos de la empresa");
                return new TOTransaction<Gnlogo>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch(Exception ex)
            {
                return new TOTransaction<Gnlogo>() { retorno = 1, txtRetorno = ex.Message,objTransaction=null };
            }
           
        }
    }
}