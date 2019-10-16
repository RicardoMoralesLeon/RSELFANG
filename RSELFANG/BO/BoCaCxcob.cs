using RSELFANG.DAO;
using RSELFANG.Models;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BoCaCxcob
    {
        DAOCaCxcob dao = new DAOCaCxcob();
        string emp_codi;
        public BoCaCxcob()
        {
            emp_codi = ConfigurationManager.AppSettings["emp_codi"];
        }
        public TOTransaction<List<ToCaCxcob>> getcacxcob(string cli_coda,DateTime cxc_fech)
        {
            try
            {
                if (string.IsNullOrEmpty(emp_codi))
                    throw new Exception("Código de empresa no parametrizado en api");
                var result = dao.getcacxcob(int.Parse(emp_codi), cli_coda, cxc_fech);
                if (result == null || !result.Any())
                    throw new Exception("El afiliado se encuentra al día por concepto de cartera.");
                return new TOTransaction<List<ToCaCxcob>> { ObjTransaction = result, Retorno = 0, TxtError = "" };

            }
            catch(Exception ex)
            {
                return new TOTransaction<List<ToCaCxcob>> { ObjTransaction = null, Retorno = 1, TxtError = ex.Message };
            }
        }
        
    }
}