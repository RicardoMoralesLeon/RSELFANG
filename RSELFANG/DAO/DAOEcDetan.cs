using RSELFANG.Models;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOEcDetan
    {
        public List<TOEcDetan> GetEcDetan(int emp_codi, int cot_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("    SELECT EC_DETAN.AUD_ESTA,                           ");
            sql.Append("    EC_DETAN.AUD_USUA,                                  ");
            sql.Append("    EC_DETAN.AUD_UFAC,                                  ");
            sql.Append("    EC_DETAN.EMP_CODI,                                  ");
            sql.Append("    EC_DETAN.COT_CONT,                                  ");
            sql.Append("    EC_DETAN.DET_CONT,                                  ");
            sql.Append("    EC_DETAN.FAC_CONT,                                  ");
            sql.Append("    EC_DETAN.DET_VANT,                                  ");
            sql.Append("    EC_DETAN.DET_VLEG,                                  ");
            sql.Append("    EC_DETAN.DET_SALD,                                  ");
            sql.Append("    FA_FACTU.TOP_CODI,                                  ");
            sql.Append("    FA_FACTU.FAC_NUME,                                  ");
            sql.Append("    FA_FACTU.FAC_FECH,                                  ");
            sql.Append("    FA_FACTU.CLI_CODI,                                  ");
            sql.Append("    GN_TOPER.TOP_NOMB                                   ");
            sql.Append("    FROM   EC_DETAN,                                    ");
            sql.Append("    FA_FACTU,                                           ");
            sql.Append("    GN_TOPER                                            ");
            sql.Append("    WHERE  EC_DETAN.EMP_CODI = FA_FACTU.EMP_CODI        ");
            sql.Append("    AND EC_DETAN.FAC_CONT = FA_FACTU.FAC_CONT           ");
            sql.Append("    AND FA_FACTU.EMP_CODI = GN_TOPER.EMP_CODI           ");
            sql.Append("    AND FA_FACTU.TOP_CODI = GN_TOPER.TOP_CODI           ");
            sql.Append("    AND EC_DETAN.EMP_CODI = @EMP_CODI                   ");
            sql.Append("    AND EC_DETAN.COT_CONT = @COT_CONT                   ");

            List<SQLParams> sqParams = new List<SQLParams>();
            sqParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqParams.Add(new SQLParams("COT_CONT", cot_cont));
            return new DbConnection().GetList<TOEcDetan>(sql.ToString(), sqParams);

        }
    }
}