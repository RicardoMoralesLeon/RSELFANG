using RSELFANG.BO;
using RSELFANG.TO;
using System.Collections.Generic;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class SfForpoController : ApiController
    {  
        [Route("api/Fovis/SfForpoInitInfo")]
        public TOTransaction<SfFovis> Get(int emp_codi)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInitialDataSf(emp_codi);
        }

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
        public TOTransaction<List<SfPostu>> Get(int emp_codi, bool optVal = true, bool optVal2 = true)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoIdPostulante(emp_codi);
        }

        [Route("api/Fovis/SfForpoInfoPostulante")]
        public TOTransaction<SfFovis> Get(int emp_codi, int afi_cont, bool validTope)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoPostulante(emp_codi, afi_cont, validTope);
        }

        [Route("api/Fovis/SfForpoValidPostulante")]
        public TOTransaction<sfforpo> Get(int emp_codi, int afi_cont, int optVal = 0, int optVal2 = 0)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetValidInfoPostulante(emp_codi, afi_cont);
        }

        [Route("api/Fovis/SfForpoGetInfo")]
        public TOTransaction<SfFovis> Get(int emp_codi, int rad_nume, int for_cont, string optVal = "")
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoAportante(emp_codi, rad_nume, for_cont);
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
        public TOTransaction<InfoAportante> Get(int emp_codi, int afi_trab, int afi_cont, string afi_docu, bool optVal = false)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoOtrosM(emp_codi, afi_trab, afi_cont, afi_docu);
        }

        [Route("api/Fovis/SfForpoInfoModvi")]
        public TOTransaction<sfdmodv> Get(int emp_codi, int mod_cont, double for_sala)
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
    }
}
