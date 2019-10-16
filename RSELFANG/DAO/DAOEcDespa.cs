using RSELFANG.Models;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOEcDespa
    {
        public List<TOEcDespa> GetEcDespa(int emp_codi, int cot_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("  SELECT ");
            sql.Append("  EC_DESPA.EMP_CODI,                                  ");
            sql.Append("  EC_DESPA.COT_CONT,                                  ");
            sql.Append("  EC_DESPA.DES_CONT,                                  ");
            sql.Append("  EC_DESPA.DES_FING,                                  ");
            sql.Append("  EC_DESPA.DES_NDIA,                                  ");
            sql.Append("  EC_DESPA.DES_FSAL,                                  ");
            sql.Append("  EC_DESPA.ESP_CONT,                                  ");
            sql.Append("  EC_DESPA.DES_CAPA,                                  ");
            sql.Append("  EC_DESPA.TER_CODI,                                  ");
            sql.Append("  EC_DESPA.TIP_CODI,                                  ");
            sql.Append("  EC_DESPA.DES_DINV,                                  ");
            sql.Append("  EC_DESPA.DES_NINV,                                  ");
            sql.Append("  EC_DESPA.PRO_CONT,                                  ");
            sql.Append("  EC_DESPA.DES_TARI,                                  ");
            sql.Append("  EC_DESPA.DES_TDES,                                  ");
            sql.Append("  EC_DESPA.DES_VDES,                                  ");
            sql.Append("  EC_DESPA.DES_CARE,                                  ");
            sql.Append("  EC_DESPA.RES_CONT,                                  ");
            sql.Append("  AE_ESPAC.ESP_CODI,                                  ");
            sql.Append("  AE_ESPAC.ESP_NOMB,                                  ");
            sql.Append("  AE_CLASE.CLA_CONT,                                  ");
            sql.Append("  AE_CLASE.CLA_CODI,                                  ");
            sql.Append("  AE_CLASE.CLA_NOMB,                                  ");
            sql.Append("  AE_CLASE.CLA_CLTI,                                  ");
            sql.Append("  AE_CLASE.LIP_CONT,                                  ");
            sql.Append("  AE_TIPOS.TIP_CONT TIP_CONT_E,                       ");
            sql.Append("  AE_TIPOS.TIP_CODI TIP_CODI_E,                       ");
            sql.Append("  AE_TIPOS.TIP_NOMB TIP_NOMB_E,                       ");
            sql.Append("  GN_TERCE.TER_CODA,                                  ");
            sql.Append("  GN_TERCE.TER_NOCO,                                  ");
            sql.Append("  GN_TIPDO.TIP_ABRE,                                  ");
            sql.Append("  IN_PRODU.PRO_CODI,                                  ");
            sql.Append("  IN_PRODU.PRO_NOMB,                                  ");
            sql.Append("  AE_ESPAC.BOD_CODI,                                  ");
            sql.Append("  AE_RESER.RES_FECH,                                  ");
            sql.Append("  AE_RESER.RES_FINI,                                  ");
            sql.Append("  AE_ESPAC.ESP_MDIT                                   ");
            sql.Append("  FROM   EC_DESPA                                     ");
            sql.Append("  INNER JOIN AE_ESPAC                                 ");
            sql.Append("  ON EC_DESPA.EMP_CODI = AE_ESPAC.EMP_CODI            ");
            sql.Append("  AND EC_DESPA.ESP_CONT = AE_ESPAC.ESP_CONT           ");
            sql.Append("  INNER JOIN AE_CLASE                                 ");
            sql.Append("  ON  AE_ESPAC.EMP_CODI = AE_CLASE.EMP_CODI           ");
            sql.Append("  AND AE_ESPAC.CLA_CONT = AE_CLASE.CLA_CONT           ");
            sql.Append("  INNER JOIN AE_TIPOS                                 ");
            sql.Append("  ON  AE_ESPAC.EMP_CODI = AE_TIPOS.EMP_CODI           ");
            sql.Append("  AND AE_ESPAC.TIP_CONT = AE_TIPOS.TIP_CONT           ");
            sql.Append("  INNER JOIN GN_TERCE                                 ");
            sql.Append("  ON  EC_DESPA.EMP_CODI = GN_TERCE.EMP_CODI           ");
            sql.Append("  AND EC_DESPA.TER_CODI = GN_TERCE.TER_CODI           ");
            sql.Append("  LEFT JOIN GN_TIPDO                                  ");
            sql.Append("  ON  GN_TIPDO.TIP_CODI = EC_DESPA.TIP_CODI           ");
            sql.Append("  LEFT JOIN IN_PRODU                                  ");
            sql.Append("  ON  IN_PRODU.EMP_CODI = EC_DESPA.EMP_CODI           ");
            sql.Append("  AND IN_PRODU.PRO_CONT = EC_DESPA.PRO_CONT           ");
            sql.Append("  LEFT JOIN AE_RESER                                  ");
            sql.Append("  ON  AE_RESER.EMP_CODI = EC_DESPA.EMP_CODI           ");
            sql.Append("  AND AE_RESER.RES_CONT = EC_DESPA.RES_CONT           ");
            sql.Append("  WHERE EC_DESPA.EMP_CODI = @EMP_CODI                  ");
            sql.Append("  AND EC_DESPA.COT_CONT = @COT_CONT                    ");
            List<SQLParams> sqParams = new List<SQLParams>();
            sqParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqParams.Add(new SQLParams("COT_CONT", cot_cont));
            return new DbConnection().GetList<TOEcDespa>(sql.ToString(), sqParams);
        }
    }
}