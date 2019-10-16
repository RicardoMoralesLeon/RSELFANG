using RSELFANG.TO;
using SevenFramework.DataBase;
using SevenFramework.DataBase.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOCtContr
    {       
        public List<CtContr> GetCtContr(int emp_codi, string cli_coda)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("   SELECT CT_CONTR.CON_CONT,                           ");
            sql.Append("   CT_CONTR.CON_NCON,                                  ");
            sql.Append("   CT_CONTR.CON_DESC,                                  ");
            sql.Append("   CT_CONTR.CON_NUME,                                  ");
            //sql.Append("   CT_CONTR.CON_FECH,                                  ");
            sql.Append("   CT_CONTR.TOP_CODI,                                  ");
            sql.Append("   GN_TOPER.TOP_NOMB,                                  ");
            sql.Append("   GN_TERCE.TER_CODA,                                  ");
            sql.Append("   GN_TERCE.TER_NOCO                                   ");
            sql.Append("   FROM   CT_CONTR,                                    ");
            sql.Append("   GN_TERCE,                                           ");
            sql.Append("   GN_TOPER                                            ");
            sql.Append("   WHERE  CT_CONTR.EMP_CODI = GN_TERCE.EMP_CODI        ");
            sql.Append("   AND CT_CONTR.TER_CODI = GN_TERCE.TER_CODI           ");
            sql.Append("   AND CT_CONTR.EMP_CODI = GN_TOPER.EMP_CODI           ");
            sql.Append("   AND CT_CONTR.TOP_CODI = GN_TOPER.TOP_CODI           ");
            sql.Append("   AND CT_CONTR.EMP_CODI = @EMP_CODI                       ");
            sql.Append("   AND CT_CONTR.CON_ESTA = 'A'                         ");
            sql.Append("   AND CON_CCLA = 'A'                                  ");
            sql.Append("   AND CT_CONTR.CON_CLAS IN('T','D')                   ");
            sql.Append("   AND GN_TERCE.TER_CODA = @TER_CODA                    ");
            List<SQLParams> sQLParams = new List<SQLParams>();
            sQLParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sQLParams.Add(new SQLParams("TER_CODA", cli_coda));
            return new DbConnection().GetList<CtContr>(sql.ToString(), sQLParams);
        }


        public CtContr GetCtCont(int con_cont,int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT con_cont, con_ncon, con_desc, con_nume, con_fech, con_tdis ");
            sql.Append(" FROM CT_CONTR WHERE                                               ");
            sql.Append(" EMP_CODI = @EMP_CODI  AND CON_CONT =  @CON_CONT                   ");
            List<SQLParams> sqlparams = new List<SQLParams>()
            {
                new SQLParams("EMP_CODI",emp_codi),
                new SQLParams("CON_CONT",con_cont)

            };
           
            sql = sql.Replace("CtContr", "CT_CONTR");
            return new DbConnection().Get<CtContr>(sql.ToString(), sqlparams);
        }



        public GnArbol GetCtDcont(int con_cont,int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("   SELECT GN_ARBOL.ARB_NOMB,                       ");
            sql.Append("   GN_ARBOL.ARB_CODI,                              ");
            sql.Append("   GN_ARBOL.ARB_CONT                               ");
            sql.Append("   FROM   CT_DCONT                                 ");
            sql.Append("   INNER JOIN CT_DDISP                             ");
            sql.Append("   ON CT_DCONT.EMP_CODI = CT_DDISP.EMP_CODI        ");
            sql.Append("   AND CT_DCONT.CON_CONT = CT_DDISP.CON_CONT       ");
            sql.Append("   AND CT_DCONT.DCO_CONT = CT_DDISP.DCO_CONT       ");
            sql.Append("   INNER JOIN GN_ARBOL                             ");
            sql.Append("   ON  CT_DDISP.ARB_CONT = GN_ARBOL.ARB_CONT       ");
            sql.Append("   AND CT_DDISP.EMP_CODI = GN_ARBOL.EMP_CODI       ");
            sql.Append("   AND GN_ARBOL.TAR_CODI = CT_DDISP.TAR_CODI       ");
            sql.Append("   AND GN_ARBOL.TAR_CODI = 1                       ");
            sql.Append("   WHERE CT_DCONT.EMP_CODI = @EMP_CODI                   ");
            sql.Append("   AND CT_DCONT.CON_CONT = @CON_CONT                  ");
            sql.Append("   AND CT_DCONT.DCO_CONT = 1                       ");
            List<SQLParams> sQLParams = new List<SQLParams>();
            sQLParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sQLParams.Add(new SQLParams("CON_CONT", con_cont));
            return new DbConnection().Get<GnArbol>(sql.ToString(), sQLParams);
        }

        public GnArbol GetCtDcontManual(int con_cont,int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("   SELECT GN_ARBOL.ARB_NOMB,               ");
            sql.Append("   GN_ARBOL.ARB_CODI,                             ");
            sql.Append("   GN_ARBOL.ARB_CONT                              ");
            sql.Append("   FROM   CT_DCONT                                ");
            sql.Append("   LEFT JOIN CT_DDMAN                             ");
            sql.Append("   ON CT_DCONT.EMP_CODI = CT_DDMAN.EMP_CODI       ");
            sql.Append("   AND CT_DCONT.CON_CONT = CT_DDMAN.CON_CONT      ");
            sql.Append("   AND CT_DCONT.DCO_CONT = CT_DDMAN.DCO_CONT      ");
            sql.Append("   INNER JOIN GN_ARBOL                            ");
            sql.Append("   ON  CT_DDMAN.ARB_AREA = GN_ARBOL.ARB_CONT      ");
            sql.Append("   AND CT_DDMAN.EMP_CODI = GN_ARBOL.EMP_CODI      ");
            sql.Append("   AND GN_ARBOL.TAR_CODI = 1                      ");
            sql.Append("   WHERE CT_DCONT.EMP_CODI = @EMP_CODI                  ");
            sql.Append("   AND CT_DCONT.CON_CONT = @CON_CONT                 ");
            sql.Append("   AND CT_DCONT.DCO_CONT = 1                      ");
            List<SQLParams> sQLParams = new List<SQLParams>();
            sQLParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sQLParams.Add(new SQLParams("CON_CONT", con_cont));
            return new DbConnection().Get<GnArbol>(sql.ToString(), sQLParams);
        }
    }
}