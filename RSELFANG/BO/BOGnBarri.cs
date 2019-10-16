using System;
using System.Collections.Generic;
using System.Linq;
using RSELFANG.DAO;
using RSELFANG.TO;

namespace RSELFANG.BO
{
    public class BOGnBarri
    {
        public List<GnBarri> GetGnBarri(int pai_codi, int reg_codi, int dep_codi, int mun_codi, int loc_codi)
        {
            DAOGnBarri dao = new DAOGnBarri();
            List<GnBarri> result = new List<GnBarri>();
            result = dao.GetGnBarri(pai_codi, reg_codi, dep_codi, mun_codi, loc_codi);
            if (result == null || !result.Any())
                throw new Exception("No se encontraron barrios parametrizados en Seven-Erp");
            return result;
        }
    }
}