using RSELFANG.TO;
using RSELFANG.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOGnTipdo
    {
        public List<GnTipdo> GetGnTipdo()
        {
            DAOGnTipdo dao = new DAOGnTipdo();
            List<GnTipdo> result = new List<GnTipdo>();
            result = dao.getListGnTipdo();
            if (result == null || !result.Any())
                throw new Exception("No se encontraron tipos de documento parametrizados en Seven-Erp");
            return result;
        }
    }
}