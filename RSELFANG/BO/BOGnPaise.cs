using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOGnPaise
    {
       public List<GnPaise> GetGnPaise()
        {
           
                DAOGnPaise dao = new DAOGnPaise();
                List<GnPaise> result = new List<GnPaise>();
                result = dao.GetGnPaise();
                if (result == null || !result.Any())
                    throw new Exception("No se encontraron países parametrizados en Seven-Erp");
            return result;
            
            
        }
    }
}