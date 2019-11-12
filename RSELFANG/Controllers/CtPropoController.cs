using RSELFANG.BO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RSELFANG.Controllers
{
    public class CtPropoController : ApiController
    {        
        [Route("api/CtPropo/CtPropoLoad")]
        public TOTransaction<CtPropoLoad> Get(int emp_codi)
        {
            BOCtPropo bo = new BOCtPropo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInitialDataCtPropo(emp_codi);
        }

        [Route("api/CtPropo/LoadRegiones")]
        public TOTransaction<CtPropoLoad> Get(int emp_codi ,int pai_codi)
        {
            BOCtPropo bo = new BOCtPropo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetRegiones(emp_codi, pai_codi);
        }

        [Route("api/CtPropo/LoadDeptos")]
        public TOTransaction<CtPropoLoad> Get(int emp_codi, int pai_codi, int reg_codi)
        {
            BOCtPropo bo = new BOCtPropo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetDepartamentos(emp_codi, pai_codi, reg_codi);
        }

        [Route("api/CtPropo/LoadMunic")]
        public TOTransaction<CtPropoLoad> Get(int emp_codi, int pai_codi, int reg_codi, int dep_codi)
        {
            BOCtPropo bo = new BOCtPropo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetMunicipios(emp_codi, pai_codi, reg_codi, dep_codi);
        }

        [Route("api/CtPropo/LoadLocal")]
        public TOTransaction<CtPropoLoad> Get(int emp_codi, int pai_codi, int reg_codi, int dep_codi, int mun_codi)
        {
            BOCtPropo bo = new BOCtPropo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetLocalidades(emp_codi, pai_codi, reg_codi, dep_codi,mun_codi);
        }

        [Route("api/CtPropo/LoadBarri")]
        public TOTransaction<CtPropoLoad> Get(int emp_codi, int pai_codi, int reg_codi, int dep_codi, int mun_codi, int loc_codi)
        {
            BOCtPropo bo = new BOCtPropo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetBarrios(emp_codi, pai_codi, reg_codi, dep_codi, mun_codi, loc_codi);
        }

        [Route("api/CtPropo/InsertPropo")]
        public TOTransaction<CtRevPrSalida> Post(CtPropo propo)
        {
            BOCtPropo bo = new BOCtPropo();
            propo.emp_codi = new tools.General().GetEmpCodi(propo.emp_codi);
            return bo.PostPropo(propo);
        }

        [Route("api/CtPropo/InsertTraDa")]
        public TOTransaction<CtRevPrSalida> Post(myObject revtd)
        {
            BOCtPropo bo = new BOCtPropo();
            revtd.emp_codi = new tools.General().GetEmpCodi(revtd.emp_codi);
            return bo.InsertTratDatos(revtd);
        }
                
        [Route("api/CtPropo/InsertActiv")]
        public TOTransaction<CtRevPrSalida> Post(int emp_codi, int rev_cont, List<GnArbol> ctacxpr)
        {
            BOCtPropo bo = new BOCtPropo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.InsertActividades(emp_codi, rev_cont, ctacxpr);
        }

        [Route("api/CtPropo/InsertDoctos")]
        public TOTransaction<CtRevDoSalida> Post(int emp_codi, int rev_cont, List<CtDocpr> ctdocpr)
        {
            BOCtPropo bo = new BOCtPropo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.InsertDocumentos(emp_codi, rev_cont, ctdocpr);
        }

        [Route("api/CtPropo/RollBackPropo")]
        public TOTransaction<CtRevDoSalida> Post(int emp_codi, int rev_cont)
        {
            BOCtPropo bo = new BOCtPropo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.deletePropo(emp_codi, rev_cont);
        }

        [Route("api/CtPropo/sendMail")]
        public TOTransaction<CtRevPrSalida> Get(string mailPropo, int emp_codi= 0)
        {
            BOCtPropo bo = new BOCtPropo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.sendMailPropo(mailPropo);
        }

    }
}
