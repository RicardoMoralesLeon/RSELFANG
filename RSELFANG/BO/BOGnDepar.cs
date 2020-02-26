using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOGnDepar
    {
        public List<GnDepar> GetGnDepar(int pai_codi)
        {

            DAOGnDepar dao = new DAOGnDepar();
            List<GnDepar> result = new List<GnDepar>();
            result = dao.GetGnDepar(pai_codi);
            if (result == null || !result.Any())
                throw new Exception("No se encontraron departamentos parametrizados en Seven-Erp");
            return result;

        }

        public List<GnDepar> GetGnDepar(int pai_codi, int reg_codi)
        {
            DAOGnDepar dao = new DAOGnDepar();
            List<GnDepar> result = new List<GnDepar>();
            result = dao.GetGnDepar(pai_codi, reg_codi);            
            return result;
        }
    }
}