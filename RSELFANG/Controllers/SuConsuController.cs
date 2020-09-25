using System;
using System.Collections.Generic;
using System.Web.Http;
using RSELFANG.BO;
using RSELFANG.TO;


namespace RSELFANG.Controllers
{
    public class SuConsuController : ApiController
    {
        [Route("api/SuConsu/afiliatrabLoad")]
        public TOTransaction<tofiliatrab> Get(int emp_codi, string usu_codi)
        {
            BoSuconsu bo = new BoSuconsu();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoAfilitrab(emp_codi, usu_codi);
        }

        [Route("api/SuConsu/afilNovedadLoad")]
        public TOTransaction<List<toRnRadic>> Get(int emp_codi, int afi_cont, DateTime rad_feci,  DateTime rad_fecf)
        {
            BoSuconsu bo = new BoSuconsu();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoAfilNovedad(emp_codi, afi_cont, rad_feci, rad_fecf);
        }

        [Route("api/SuConsu/afiAportesLoad")]
        public TOTransaction<List<toArDpil>> Get(int emp_codi, int afi_cont, int rpi_peri, int rpi_perf)
        {
            BoSuconsu bo = new BoSuconsu();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.getInfoAportes(emp_codi, afi_cont, rpi_peri, rpi_perf);
        }        
    }
}
