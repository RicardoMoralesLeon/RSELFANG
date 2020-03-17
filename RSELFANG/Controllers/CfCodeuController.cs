
using Digitalware.Apps.Utilities.Cf.BO;
using Digitalware.Apps.Utilities.Cf.Models;
using SevenFramework.TO;
using System.Collections.Generic;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class CfCodeuController : ApiController
    {
        // GET: api/CfCodeu
        [HttpGet]
        [Route("api/CfCodeu")]
        public TOTransaction<Cf_CodeuGet>  Get(int emp_codi,string cod_dnum)
        {
            return new BO_Cf_Codeu().GetCfCodeu(emp_codi, cod_dnum);
        }

        [HttpPost]
        [Route("api/CfCodeu")]
        public TOTransaction SetCfCodeu(Cf_Codeu codeudor)
        {
            return new BO_Cf_Codeu().SetCfCodeu(codeudor);
        } 

      
    }
}
