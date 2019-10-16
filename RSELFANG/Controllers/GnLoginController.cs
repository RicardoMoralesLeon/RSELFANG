using DigitalWare.Apps.Utilities.Gn.BO;
using RSELFANG.Models;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class GnLoginController : ApiController
    {
        /// <summary>
        /// login controller para autenticación de usuarios
        /// </summary>
        [AllowAnonymous]
        [RoutePrefix("api/login")]
        public class LoginController : ApiController
        {
            [HttpGet]
            [Route("echoping")]
            public IHttpActionResult EchoPing()
            {
                return Ok(true);
            }

            [HttpGet]
            [Route("echouser")]
            public IHttpActionResult EchoUser()
            {
                var identity = Thread.CurrentPrincipal.Identity;
                return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
            }

            [HttpPost]
            [Route("authenticate")]
            public IHttpActionResult Authenticate(LoginRequest login)
            {
                if (login == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                //TODO: validar las credenciales aquí
                bool isCredentialValid = new BOGnUsuar().GnUsuarAutenticate(login.Username, login.Password).Retorno == 0;
                if (isCredentialValid)
                {
                    var token = TokenGenerator.GenerateTokenJwt(login.Username);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }

            [HttpPost]
            [Route("ForgetPassword")]
            public IHttpActionResult ForgetPassword(LoginRequestForgetPassword login)
            {
                try
                {
                    string link = ConfigurationManager.AppSettings["JWT_TRANSACT_SITE"];
                    if (string.IsNullOrEmpty(link))
                        throw new Exception("Llave JWT_TRANSACT_SITE no parametrizada.Contacte con su administrador de la configuración");
                    BOGnUsuar bo = new BOGnUsuar();
                    if (login == null)
                        throw new HttpResponseException(HttpStatusCode.BadRequest);
                    //TODO: validar las credenciales genéricas aquí
                    bool isCredentialValid = bo.GnUsuarAutenticate(login.Username, login.Password).Retorno == 0;
                    if (isCredentialValid)
                    {
                        if (string.IsNullOrEmpty(login.LoginUser))
                            throw new Exception("El usuario a restaurar no puede estar vacío");
                        var token = TokenGenerator.GenerateTokenJwt(login.LoginUser);
                        bo.SendMailForgetPasswordToUser(login.LoginUser, token, link);
                        return Ok(new TOTransaction() { Retorno = 0, TxtError = "" });
                 
                    }
                    else
                    {
                        return Ok(new TOTransaction() { Retorno=1,TxtError=string.Format( "Credenciales para el usuario {0} no válidas" , login.Username)});
                    }
                }
                catch (Exception ex)
                {

                    return Ok(new TOTransaction() { TxtError = ex.Message, Retorno = 1 });
                }
               
            }
        }
    }
}
