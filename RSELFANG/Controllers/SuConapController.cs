using System;
using System.Collections.Generic;
using System.Web.Http;
using RSELFANG.BO;
using RSELFANG.TO;

namespace RSELFANG.Controllers
{
    public class SuConapController : ApiController
    {
        [Route("api/SuConap/arApovoLoad")]
        public TOTransaction<toArApovoInfo> Get(int emp_codi, string usu_codi)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoArApovo(emp_codi, usu_codi);
        }

        [Route("api/SuConap/afiliatrabLoad")]
        public TOTransaction<tofiliatrab> Get(int emp_codi,int tip_codi, string afi_docu, int apo_cont)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoAfilitrab(emp_codi, tip_codi, afi_docu, apo_cont);
        }

        [Route("api/SuConap/afilNovedadLoad")]
        public TOTransaction<List<toRnRadic>> Get(int emp_codi, string apo_coda, DateTime rad_feci, DateTime rad_fecf)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoAfilNovedad(emp_codi, apo_coda, rad_feci, rad_fecf);
        }

        [Route("api/SuConap/afilNovedadTrabLoad")]
        public TOTransaction<List<toRnRadic>> Get(int emp_codi, int tip_codi, string afi_docu, string rad_feci, string rad_fecf, string apo_coda)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getAfilNovedadTrabLoad(emp_codi, tip_codi, afi_docu, rad_feci, rad_fecf, apo_coda);
        }

        [Route("api/SuConap/infoAportesTrabLoad")]
        public TOTransaction<List<toArDpil>> Get(int emp_codi, int tip_codi, string afi_docu, int rad_feci, int rad_fecf, string apo_coda, bool opt = false)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoAportes(emp_codi, afi_docu, rad_feci, rad_fecf, apo_coda, tip_codi);
        }

        [Route("api/SuConap/afiSubsidiosTrabLoad")]
        public TOTransaction<List<ToSuHgicm>> Get(int emp_codi, int hgi_peri, int hgi_perf, string afi_docu, int tip_codi, string apo_coda)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoSubsidios(emp_codi, hgi_peri, hgi_perf, afi_docu, tip_codi, apo_coda);
        }

        [Route("api/SuConap/infoAportesEmpLoad")]
        public TOTransaction<List<toArDpil>> Get(int emp_codi,int rad_feci, int rad_fecf, string apo_coda, bool opt = false)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoAportesEmpresa(emp_codi, rad_feci, rad_fecf, apo_coda);
        }

        [Route("api/SuConap/infoAportesFiscal")]
        public TOTransaction<List<toArDpil>> Get(int emp_codi, int rpi_peri, string apo_coda)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoAportesFiscal(emp_codi, rpi_peri, apo_coda);
        }

        [Route("api/SuConap/InfoDevoluciones")]
        public TOTransaction<List<toRnRadic>> Get(int emp_codi, DateTime rad_feci, DateTime rad_fecf, string apo_coda, bool opt = false)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoDevoluciones(emp_codi, apo_coda, rad_feci, rad_fecf);
        }

        [Route("api/SuConap/InfoDetalleDevolucion")]
        public TOTransaction<ArRdevo> Get(int emp_codi, int rad_cont)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoDevoDetalle(emp_codi, rad_cont);
        }

        [Route("api/SuConap/empSubsidiosLoad")]
        public TOTransaction<List<ToSuHgicm>> Get(int emp_codi, int hgi_peri, int hgi_perf, string apo_coda)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoSubsidiosEmpresa(emp_codi, hgi_peri, hgi_perf, apo_coda);
        }       
    }
}
