using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RSELFANG.BO
{
    public class BOGnRegio
    {
        public List<GnRegio> GetGnRegio(int pai_codi)
        {
            DAOGnRegi dao = new DAOGnRegi();
            List<GnRegio> result = new List<GnRegio>();
            result = dao.GetGnRegio(pai_codi);
            if (result == null || !result.Any() || result.Count == 0)
                throw new Exception("No se encontraron regiones parametrizadas en seven -erp");
            return result;
        }
    }
}