using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RSELFANG.tools
{
    public class General
    {

        public int GetEmpCodi(int emp_codi)
        {           
            if (emp_codi == 0)
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["emp_codi"]))
                    throw new Exception("Código de empresa no definido en api");
                return int.Parse(ConfigurationManager.AppSettings["emp_codi"]);
            }
            else
            {
                return emp_codi;
            }


        }
    }
}