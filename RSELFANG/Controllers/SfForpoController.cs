using RSELFANG.BO;
using RSELFANG.TO;
using System.Collections.Generic;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class SfForpoController : ApiController
    {
        [Route("api/Fovis/SfForpoInfoModalidad")]
        public TOTransaction<List<SfFovisInfo>> Get(int emp_codi, int optVal = 0)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoModalidad(emp_codi);
        }

        [Route("api/Fovis/SfForpoInfoRadicado")]
        public TOTransaction<List<SfRadic>> Get(int emp_codi, int optVal = 0, int optVal2 = 0)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoRadicado(emp_codi);
        }

        [Route("api/Fovis/SfForpoIdPostulante")]
        public TOTransaction<SfPostu> Get(int emp_codi, string afi_docu,bool optVal = true, bool optVal2 = true)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoIdPostulante(emp_codi, afi_docu);
        }             

        [Route("api/Fovis/SfForpoValidPostulante")]
        public TOTransaction<sfforpo> Get(int emp_codi, int afi_cont, int optVal = 0, int optVal2 = 0)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetValidInfoPostulante(emp_codi, afi_cont);
        }
    
        [Route("api/Fovis/SfForpoGnItems")]
        public TOTransaction<List<GnItems>> Get(int tit_cont, bool opt_val1 = false)
        {
            BOSfForpo bo = new BOSfForpo();            
            return bo.GetGnItems(tit_cont);
        }
 
       [Route("api/Fovis/SfForpoValidInfoConyu")]
        public TOTransaction<InfoAportante> Get(int emp_codi, int afi_cont, bool optVal = false, string optValud = "")
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoConyuge(emp_codi, afi_cont);
        }

        [Route("api/Fovis/SfForpoIdConyuge")]
        public TOTransaction<List<SfPostu>> Get(int emp_codi, int afi_cont ,string optVal = "", bool optVal2 = true)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoIdConyuge(emp_codi, afi_cont);
        }


        [Route("api/Fovis/SfForpoIdPerca")]
        public TOTransaction<List<SfPostu>> Get(int emp_codi, int afi_cont, bool optVal = false, bool optVal2 = true)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoIdPerca(emp_codi, afi_cont);
        }

        [Route("api/Fovis/SfForpoOtrosM")]
        public TOTransaction<InfoAportante> Get(int emp_codi, int afi_trab, string afi_docu, bool optVal = false, bool optVal2 = false)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoOtrosM(emp_codi, afi_trab, afi_docu);
        }

        [Route("api/Fovis/SfForpoInfoModvi")]
        public TOTransaction<InfoDfoih> Get(int emp_codi, int mod_cont, double for_sala)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoIngresos(emp_codi, mod_cont, for_sala);
        }

        [Route("api/Fovis/SfForpoGetConcepto")]
        public TOTransaction<List<sfconec>> Get(int emp_codi, string con_tipo ,double optVal = 0)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoConceptos(emp_codi, con_tipo);
        }

        [Route("api/Fovis/SfForpoGetParentesco")]
        public TOTransaction<List<GnItems>> Get()
        {
            BOSfForpo bo = new BOSfForpo();           
            return bo.GetGnItems(487);
        }
        
        [Route("api/Fovis/SfForpoGetTratamiento")]
        public TOTransaction<string> Get(int emp_codi, bool val = false, bool val2 = false)
        {
            BOSfForpo bo = new BOSfForpo();
            return bo.GetTratamiento(emp_codi);
        }

        [Route("api/Fovis/SfForpoGetSfParam")]
        public TOTransaction<Sfparam> Get(int emp_codi, string val = "", bool val2 = false)
        {
            BOSfForpo bo = new BOSfForpo();
            return bo.GetSfParam(emp_codi);
        }

        [Route("api/Fovis/SfForpoGetTDocumento")]
        public TOTransaction<List<GnTipdo>> Get(int emp_codi, string val = "", string val2 = "")
        {
            BOSfForpo bo = new BOSfForpo();
            return bo.GetTipDocumento(emp_codi);
        }

        [Route("api/Fovis/SfForpoGetNomencla")]
        public TOTransaction<string> Get(bool val = false)
        {
            BOSfForpo bo = new BOSfForpo();
            return bo.GetNomenclatura();
        }

        [Route("api/Fovis/SfForpoGetConstructora")]
        public TOTransaction<List<PoPvdor>> Get(int emp_codi, string val2 = "")
        {
            BOSfForpo bo = new BOSfForpo();
            return bo.GetPoPvdor(emp_codi);
        }

        [Route("api/Fovis/SfForpoGetInfoForpo")]
        public TOTransaction<SfFovis> Get(int emp_codi, int afi_cont, int for_cont, bool val = false)
        {
            BOSfForpo bo = new BOSfForpo();
            return bo.GetInfoForpo(emp_codi, for_cont, afi_cont);
        }

        [Route("api/Fovis/SfForpoGetInfoPostulante")]
        public TOTransaction<SfFovis> Get(int emp_codi, int afi_cont, string optval = "")
        {
            BOSfForpo bo = new BOSfForpo();
            return bo.GetInfoPostulante(emp_codi, afi_cont);
        }

        [HttpGet]
        [Route("api/Fovis/SfForpoPrintReporte")]
        public TOTransaction<string> printCertificado(string ter_coda, int emp_codi, string reporte)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.printReport(ter_coda, emp_codi, reporte);
        }
    }
}
