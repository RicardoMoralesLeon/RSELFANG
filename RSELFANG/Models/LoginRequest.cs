using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.Models
{
    public class LoginRequestForgetPassword
    {
        /// <summary>
        /// Usuario de seven genérico
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Contraseña de seven
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Usuario para el cual se genera el token
        /// </summary>
        public string LoginUser { get; set; }
    }

    public class LoginRequest
    {
        /// <summary>
        /// Usuario de seven genérico
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Contraseña de seven
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Usuario para el cual se genera el token
        /// </summary>
        public string LoginUser { get; set; }
    }
}