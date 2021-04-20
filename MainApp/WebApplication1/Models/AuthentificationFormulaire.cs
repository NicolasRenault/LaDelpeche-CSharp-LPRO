using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppliWeb1.Models
{
    public class AuthentificationFormulaire
    {
        public string ReturnMessage { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public object ReturnUrl { get; set; }
    }
}