using DigitalWare.Apps.Utilities.Gn.BO;
using RSELFANG.Models;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace RSELFANG.Controllers
{

    /// <summary>
    /// customer controller class for testing security token
    /// </summary>
    [Authorize]
    [RoutePrefix("api/gnusuar")]
    public class GnUsuarController : ApiController
    {

        [HttpPost]
        public IHttpActionResult changePassword(LoginRequest login)
        {
            try
            {
                byte[] data = System.Convert.FromBase64String(login.Password);
                BOGnUsuar bo = new BOGnUsuar();
                var identity = Thread.CurrentPrincipal.Identity;
                return Ok(bo.SetNewPassword(identity.Name, System.Text.ASCIIEncoding.ASCII.GetString(data), login.Username));
            }
            catch (Exception ex)
            {

                return Ok(new TOTransaction() { Retorno = 1, TxtError = ex.Message });
            }


        }


    }
}
