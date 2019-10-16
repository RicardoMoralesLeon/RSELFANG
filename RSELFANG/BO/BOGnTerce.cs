using RSELFANG.DAO;
using RSELFANG.TO;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOGnTerce
    {
        string emp_codi;

        public BOGnTerce(){
            emp_codi = ConfigurationManager.AppSettings["emp_codi"];
            }
        public SevenFramework.TO.TOTransaction<Gn_Terce> GetGnTerce(string usu_codi)
        {
            DAOGnTerce dao = new DAOGnTerce();
            try
            {
                if (string.IsNullOrEmpty(emp_codi))
                    throw new Exception("Código de empresa no parametrizado en api");
                var result = dao.GetGnTerceByUser(int.Parse(emp_codi), usu_codi);
                if (result == null)
                    throw new Exception("No se encontraron usuarios");
                return new SevenFramework.TO.TOTransaction<Gn_Terce>() { ObjTransaction = result, Retorno = 0, TxtError = "" };
            }
            catch(Exception ex)
            {
                return new SevenFramework.TO.TOTransaction<Gn_Terce>() { ObjTransaction = null, TxtError = ex.Message, Retorno = 1 };
            }
        }
    }
}