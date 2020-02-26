using RSELFANG.DAO;
using RSELFANG.TO;
using System.Collections.Generic;

namespace RSELFANG.BO
{
    public class BOGnPaise
    {
        public List<GnPaise> GetGnPaise()
        {
            DAOGnPaise dao = new DAOGnPaise();
            List<GnPaise> result = new List<GnPaise>();
            result = dao.GetGnPaise();
            return result;
        }
    }
}