using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOGnDigfl
    {
        public GnFlag GetGnDigfl(string dig_codi)
        {
           
                DAOGnFlag dao = new DAOGnFlag();
                GnFlag result = new GnFlag();
                result = dao.GetGnFlag(dig_codi);
                if (result == null)
                    throw new Exception( string.Format("Gndigfl {0} no encontrado",dig_codi));
            return result;

           
        }
    }
}