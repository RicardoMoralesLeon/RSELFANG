using RSELFANG.DAO;
using RSELFANG.TO;
using System.Collections.Generic;

namespace RSELFANG.BO
{
    public class BOGnRegio
    {
        public List<GnRegio> GetGnRegio(int pai_codi)
        {
            DAOGnRegi dao = new DAOGnRegi();
            List<GnRegio> result = new List<GnRegio>();
            result = dao.GetGnRegio(pai_codi);            
            return result;
        }
    }
}