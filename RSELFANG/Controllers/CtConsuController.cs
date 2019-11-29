using RSELFANG.BO;
using RSELFANG.TO;
using System.Collections.Generic;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class CtConsuController : ApiController
    {
        [Route("api/CtConsu/CtConsuLoad")]
        public TOTransaction<List<TORevPr>> Get(int emp_codi, string rev_esta, string pro_codi , string pro_nomb)
        {
            BOCtConsu bo = new BOCtConsu();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoDataCtConsu(emp_codi, rev_esta, pro_codi ,pro_nomb);
        }

        [Route("api/CtConsu/CtPropoInfoLoad")]
        public TOTransaction<CtPropo> Get(int emp_codi, int rev_cont)
        {
            BOCtConsu bo = new BOCtConsu();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoCtPropo(emp_codi, rev_cont);
        }
                
        [Route("api/CtConsu/CtPropoActividades")]
        public TOTransaction<List<GnArbol>> Get(int emp_codi, int rev_cont, int arb_cont = 0)
        {
            BOCtConsu bo = new BOCtConsu();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoCtAcxpr(emp_codi, rev_cont);
        }

        [Route("api/CtConsu/CtPropoTratamiento")]
        public TOTransaction<List<CtRevtd>> Get(int emp_codi, int rev_cont, string arb_codi = "")
        {
            BOCtConsu bo = new BOCtConsu();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoCtrevtd(emp_codi, rev_cont);
        }

        [Route("api/CtConsu/RechazarPropo")]
        public TOTransaction Post(int emp_codi, int rev_cont, int doc_cont =0)
        {
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            BOCtConsu bo = new BOCtConsu(emp_codi,rev_cont);            
            return bo.setStatePropo(emp_codi, rev_cont);
        }

        [Route("api/CtConsu/CtPropoVigencia")]
        public TOTransaction<List<CtRevdo>> get(int emp_codi, int rev_cont)
        {
            BOCtConsu bo = new BOCtConsu();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoVigencia(emp_codi, rev_cont);
        }

        [Route("api/CtConsu/ActualizarVigencia")]
        public TOTransaction Post(int emp_codi, int rev_cont, int doc_cont, bool chkApro)
        {
            BOCtConsu bo = new BOCtConsu();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.setInfoVigencia(emp_codi, rev_cont, doc_cont, chkApro);
        }


        [Route("api/CtConsu/aprobarProponente")]
        public TOTransaction Post(int emp_codi, int rev_cont, List<CtRevdo> ctrevdo)
        {
            BOCtConsu bo = new BOCtConsu();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.setInfoCtPropo(emp_codi, rev_cont, ctrevdo);
        }
    }
}
