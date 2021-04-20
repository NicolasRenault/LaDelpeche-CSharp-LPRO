using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AppliWeb1.Models;
using System.Web.UI.WebControls;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginForm()
        {
            AuthentificationFormulaire formulaire = new AuthentificationFormulaire();
            formulaire.ReturnMessage = "Veuillez vous authentifier";
            return View(formulaire);
        }

        [HttpPost]
        public ActionResult LoginForm(AuthentificationFormulaire Formulaire)
        {
            
            if (Formulaire.Login == "julien" && Formulaire.Password == "azerty")
            {
                FormsAuthentication.SetAuthCookie(Formulaire.Login, true);
                return Redirect(Formulaire.ReturnUrl);
            }
            else
            {
                Formulaire = new AuthentificationFormulaire();
                Formulaire.ReturnMessage = "Un soucis a été rencontré. Invalide login / mot de passe";

                return View(Formulaire);
            }
        }

        private ActionResult Redirect(object returnUrl)
        {
            return RedirectToRoute("GetAll");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}