using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOPqDpara
    {
      
        public List<TOGPerte> GetPqDpara(int emp_codi)
        {
           
                if (string.IsNullOrEmpty(emp_codi.ToString()))
                    throw new Exception("Código de empresa (emp_codi) no definido en api");
                DAOGPerte daoPerte = new DAOGPerte();
                List<TOGPerte> result = new List<TOGPerte>();
                result = daoPerte.GetGrupoPerteneciente(emp_codi);
                if (result == null || !result.Any())
                    throw new Exception("Grupos no definidos en pqdpara");
            return result;
          
        }
    }
}