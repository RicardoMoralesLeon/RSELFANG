using RSELFANG.Models;
using SevenFramework.DataBase;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOSeCcotiz
    {

        public List<TOEcCotiz> GetSeCcotiz(int emp_codi, string ter_coda, int sbe_cont, int fec_fini, int fec_ffin)
        {
            //Obtiene los datos del encabezdo del programa seccotiz, parámetro 0
            StringBuilder sql = new StringBuilder();
            sql.Append("    SELECT EC_COTIZ.AUD_ESTA,                                               ");
            sql.Append("    EC_COTIZ.AUD_USUA,      EC_COTIZ.EVE_CONT,                                                ");
            sql.Append("    EC_COTIZ.AUD_UFAC,                                                      ");
            sql.Append("    EC_COTIZ.EMP_CODI,                                                      ");
            sql.Append("    EC_COTIZ.COT_CONT,                                                      ");
            sql.Append("    EC_COTIZ.TOP_CODI,                                                      ");
            sql.Append("    EC_COTIZ.COT_NUME,                                                      ");
            sql.Append("    EC_COTIZ.COT_FECH,                                                      ");
            sql.Append("    EC_COTIZ.COT_NECH,                                                      ");
           
            sql.Append("    EC_COTIZ.COT_FING,                                                      ");
         
            sql.Append("    EC_COTIZ.COT_FSAL,                                                      ");
         
            sql.Append("    EC_COTIZ.COT_COOR,                                                      ");
            sql.Append("    EC_COTIZ.COT_NCOO,                                                      ");
            sql.Append("    EC_COTIZ.COT_TCOO,                                                      ");
            sql.Append("    EC_COTIZ.TER_EJEC,                                                      ");
            sql.Append("    EC_COTIZ.TER_CAPI,                                                      ");
            sql.Append("    EC_COTIZ.COT_MAIL,                                                      ");
            sql.Append("    EC_COTIZ.COT_DESC,                                                      ");
            sql.Append("    EC_COTIZ.COT_OBSE,                                                      ");
        
           
            sql.Append("    EC_COTIZ.CON_CONT,                                                      ");
            sql.Append("    EC_COTIZ.EVE_CONT,                                                      ");
            sql.Append("    EC_COTIZ.COT_ECOR,                                                      ");
            sql.Append("    GN_TOPER.TOP_NOMB,                                                      ");
         
         
            sql.Append("    GN_TERCE_EJ.TER_CODA TER_CODA_EJ,                                       ");
            sql.Append("    GN_TERCE_EJ.TER_NOCO TER_NOCO_EJ,                                       ");
            sql.Append("    GN_TERCE_CA.TER_CODA TER_CODA_CA,                                       ");
            sql.Append("    GN_TERCE_CA.TER_NOCO TER_NOCO_CA                                      ");                    
            sql.Append("    FROM EC_COTIZ                                                           ");
            sql.Append("    INNER JOIN GN_TOPER                                                     ");
            sql.Append("    ON  EC_COTIZ.EMP_CODI = GN_TOPER.EMP_CODI                               ");
            sql.Append("    AND EC_COTIZ.TOP_CODI = GN_TOPER.TOP_CODI                               ");          
            sql.Append("    INNER JOIN GN_TERCE GN_TERCE_EJ                                         ");
            sql.Append("    ON EC_COTIZ.EMP_CODI = GN_TERCE_EJ.EMP_CODI                             ");
            sql.Append("    AND EC_COTIZ.TER_EJEC = GN_TERCE_EJ.TER_CODI                            ");
            sql.Append("    LEFT JOIN GN_TERCE GN_TERCE_CA                                          ");
            sql.Append("    ON EC_COTIZ.EMP_CODI = GN_TERCE_CA.EMP_CODI                             ");
            sql.Append("    AND EC_COTIZ.TER_CAPI = GN_TERCE_CA.TER_CODI                            ");                               
            sql.Append("    INNER JOIN FA_CLIEN ON EC_COTIZ.EMP_CODI = FA_CLIEN.EMP_CODI  ");
            sql.Append("    AND FA_CLIEN.CLI_CODI = EC_COTIZ.CLI_CODI  ");
            sql.Append("   INNER JOIN GN_TERCE ON FA_CLIEN.EMP_CODI = GN_TERCE.EMP_CODI ");
            sql.Append("   AND GN_TERCE.TER_CODI = FA_CLIEN.TER_CODI");
            sql.Append("    WHERE COT_ESTA IN('A', 'P', 'B','R')                                     ");
            sql.Append("    AND EC_COTIZ.EMP_CODI = @EMP_CODI                                       ");
            sql.Append("    AND EC_COTIZ.SBE_CONT = @SBE_CONT                                       ");
            sql.Append("    AND EC_COTIZ.COT_NECH >= @FEC_FINI                                      ");
            sql.Append("    AND EC_COTIZ.COT_NECH <= @FEC_FFIN                                      ");
            sql.Append("    AND GN_TERCE.TER_CODA = @TER_CODA                                      ");


            List<SQLParams> sqparams = new List<SQLParams>();
            sqparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqparams.Add(new SQLParams("TER_CODA", ter_coda));
            sqparams.Add(new SQLParams("FEC_FINI", fec_fini));
            sqparams.Add(new SQLParams("FEC_FFIN", fec_ffin));
            sqparams.Add(new SQLParams("SBE_CONT", sbe_cont));
            return new DbConnection().GetList<TOEcCotiz>(sql.ToString(), sqparams);

        }
    }
}