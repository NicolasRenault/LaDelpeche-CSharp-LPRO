using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class MailAPIController : Controller
    {
        // GET: MailAPI
        public ActionResult IsValidMail(string mail)
        {
            bool result;
            try
            {
                var addr = new System.Net.Mail.MailAddress(mail);
                result = addr.Address == mail;
            }
            catch
            {
                result = false;
            }

            return Json(result);
        }
    }
}