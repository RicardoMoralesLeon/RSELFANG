using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOGnLocal
    {
        public List<GnLocal> GetGnLocal(int pai_codi, int reg_codi, int dep_codi, int mun_codi)
        {
            DAOGnLocal dao = new DAOGnLocal();
            List<GnLocal> result = new List<GnLocal>();
            result = dao.GetGnLocal(pai_codi, reg_codi, dep_codi, mun_codi);
            if (result == null || !result.Any())
                throw new Exception("No se encontraron localidades parametrizadas en Seven-Erp");
            return result;
        }
    }
}