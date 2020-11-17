using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using RSELFANG.BO;
using RSELFANG.TO;

namespace RSELFANG.Controllers
{
    public class RnRadicController : ApiController
    {
        [Route("api/RnRadic/RnRadicLoad")]
        public TOTransaction<TORnRadic> Get(int emp_codi, string usu_codi= "")
        {
            BoRnRadic bo = new BoRnRadic();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInitialDataRnRadic(emp_codi, usu_codi);
        }

        [Route("api/RnRadic/RnRadicLoadAfili")]
        public TOTransaction<List<SuAfili>> Get(int emp_codi, string usu_codi = "", bool param = false)
        {
            BoRnRadic bo = new BoRnRadic();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetDataSuAfili(emp_codi, usu_codi);
        }

        [Route("api/RnRadic/RnRadicLoadInfoAfili")]
        public TOTransaction<SuAfili> Get(int emp_codi, int afi_cont, bool param = false, bool param2 = false)
        {
            BoRnRadic bo = new BoRnRadic();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoAdicionalAfili(emp_codi, afi_cont);
        }

        [Route("api/RnRadic/RnCracoLoad")]
        public TOTransaction<List<RnCraco>> Get(int gru_cont,int emp_codi, string ter_coda)
        {
            BoRnRadic bo = new BoRnRadic();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetClasificacion(gru_cont,emp_codi, ter_coda);
        }

        [Route("api/RnRadic/InserRnRadic")]
        public TOTransaction<RnRadicSalida> Post(RnRadic rnradic)
        {
            BoRnRadic bo = new BoRnRadic();           
            return bo.InsertRnRadic(rnradic);
        }
        
        [Route("api/RnRadic/RnRadicTrat")]
        public TOTransaction<List<Rnradtd>> get(int emp_codi)
        {
            BoRnRadic bo = new BoRnRadic();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoTratamiento();
        }
        
        [Route("api/RnRadic/RnRadicDocu")]
        public TOTransaction<List<RnDdocu>> get(int cra_codi, bool opcion = false)
        {
            BoRnRadic bo = new BoRnRadic();
            return bo.getInfoDocumentos(cra_codi);
        }

        [Route("api/RnRadic/SuAfiliInfo")]
        public TOTransaction<List<SuAfili>> get(int emp_codi, bool opcion = false, bool opcion2 = false)
        {
            BoRnRadic bo = new BoRnRadic();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoAfiliados(emp_codi);
        }

        [Route("api/RnRadic/ArSucur")]
        public TOTransaction<List<ArSucur>> get(int emp_codi, int apo_cont)
        {
            BoRnRadic bo = new BoRnRadic();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoSucursal(emp_codi, apo_cont);
        }

        [Route("api/RnRadic/RnRadicLoadAportante")]
        public TOTransaction<ArApovo> Get(int emp_codi, string usu_codi, bool opt = false, string aopt2 ="")
        {
            BoRnRadic bo = new BoRnRadic();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInitialApovo(emp_codi, usu_codi);
        }
    }
}
