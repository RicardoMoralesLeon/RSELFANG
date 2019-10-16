﻿using System;
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

        [Route("api/RnRadic/RnCracoLoad")]
        public TOTransaction<List<RnCraco>> Get(int gru_cont,int emp_codi)
        {
            BoRnRadic bo = new BoRnRadic();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetClasificacion(gru_cont,emp_codi);
        }

        [Route("api/RnRadic/InserRnRadic")]
        public TOTransaction Post(RnRadic rnradic)
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
    }
}
