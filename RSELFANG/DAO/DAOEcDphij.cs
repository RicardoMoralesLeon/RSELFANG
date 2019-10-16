using RSELFANG.Models;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOEcDphij
    {
        public List<TOEcDphij> GetEcDphij(int emp_codi, int cot_cont, int des_cont)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" SELECT EC_DPHIJ.AUD_ESTA,                   ");
            sql.Append(" EC_DPHIJ.AUD_USUA,                          ");
            sql.Append(" EC_DPHIJ.AUD_UFAC,                          ");
            sql.Append(" EC_DPHIJ.EMP_CODI,                          ");
            sql.Append(" EC_DPHIJ.COT_CONT,                          ");
            sql.Append(" EC_DPHIJ.DPH_CONT,                          ");
            sql.Append(" EC_DPHIJ.DPP_CONT,                          ");
            sql.Append(" EC_DPHIJ.PRO_CONT,                          ");
            sql.Append(" EC_DPHIJ.BOD_CODI,                          ");
            sql.Append(" EC_DPHIJ.DPH_CANT,                          ");
            sql.Append(" EC_DPHIJ.DPH_VALO,                          ");
            sql.Append(" EC_DPHIJ.DPH_TDES,                          ");
            sql.Append(" EC_DPHIJ.DPH_VDES,                          ");
            sql.Append(" EC_DPHIJ.DSP_CODI,                          ");
            sql.Append(" EC_DPHIJ.DPH_FECH,                          ");
            sql.Append(" EC_DPHIJ.DPH_TIPO,                          ");
            sql.Append(" EC_DPHIJ.DES_CONT,                          ");
            sql.Append(" EC_DPHIJ.DPH_DESC,                          ");
            sql.Append(" EC_DPHIJ.ORD_CONT,                          ");
            sql.Append(" EC_DPHIJ.DET_CONT,                          ");
            sql.Append(" EC_DPHIJ.DPH_VADE,                          ");
            sql.Append(" IN_PRODU.PRO_CODI,                          ");
            sql.Append(" IN_PRODU.PRO_NOMB,                          ");
            sql.Append(" IN_PRODU.TIP_CODI,                          ");
            sql.Append(" IN_UNIME.UNI_NOMB,                          ");
            sql.Append(" IN_BODEG.BOD_NOMB,                          ");
            sql.Append(" IN_DSPRO.DSP_NOMB,                          ");
            sql.Append(" EC_DPPAD.PRO_CONT PRO_PADR                  ");
            sql.Append(" FROM EC_DPHIJ                               ");
            sql.Append(" INNER JOIN IN_PRODU                         ");
            sql.Append(" ON  EC_DPHIJ.EMP_CODI = IN_PRODU.EMP_CODI   ");
            sql.Append(" AND EC_DPHIJ.PRO_CONT = IN_PRODU.PRO_CONT   ");
            sql.Append(" INNER JOIN IN_UNIME                         ");
            sql.Append(" ON  IN_PRODU.EMP_CODI = IN_UNIME.EMP_CODI   ");
            sql.Append(" AND IN_PRODU.UNI_CSKU = IN_UNIME.UNI_CODI   ");
            sql.Append(" INNER JOIN IN_BODEG                         ");
            sql.Append(" ON  EC_DPHIJ.EMP_CODI = IN_BODEG.EMP_CODI   ");
            sql.Append(" AND EC_DPHIJ.BOD_CODI = IN_BODEG.BOD_CODI   ");
            sql.Append(" INNER JOIN IN_DSPRO                         ");
            sql.Append(" ON  EC_DPHIJ.EMP_CODI = IN_DSPRO.EMP_CODI   ");
            sql.Append(" AND EC_DPHIJ.DSP_CODI = IN_DSPRO.DSP_CODI   ");
            sql.Append(" INNER JOIN EC_DPPAD                         ");
            sql.Append(" ON  EC_DPHIJ.EMP_CODI = EC_DPPAD.EMP_CODI   ");
            sql.Append(" AND EC_DPHIJ.COT_CONT = EC_DPPAD.COT_CONT   ");
            sql.Append(" AND EC_DPHIJ.DPP_CONT = EC_DPPAD.DPP_CONT   ");
            sql.Append(" WHERE EC_DPHIJ.EMP_CODI = @EMP_CODI         ");
            sql.Append(" AND EC_DPHIJ.COT_CONT = @COT_CONT           ");
            sql.Append(" AND EC_DPHIJ.DES_CONT = @DES_CONT           ");
            List<SQLParams> sqParams = new List<SQLParams>();
            sqParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqParams.Add(new SQLParams("COT_CONT", cot_cont));
            sqParams.Add(new SQLParams("DES_CONT", des_cont));
            return new DbConnection().GetList<TOEcDphij>(sql.ToString(), sqParams);
        }
    }
}