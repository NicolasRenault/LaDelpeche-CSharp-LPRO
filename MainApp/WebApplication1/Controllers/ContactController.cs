using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult ContactForm()
        {
            Form Form = new Form();
            return View();
        }

        [HttpPost]
        public ActionResult ContactForm(Form Form)
        {
            MailAddress from = new MailAddress("nicolas63renault@gmail.com");

            MailAddress to = new MailAddress(Form.To);

            MailMessage msg = new MailMessage(from, to);
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Body = "Message envoyé a partir du site" + "<br/>Par : " + Form.Text +
                        "<br/>Objet : " + Form.Subject +
                        "<br/>Message : " + Form.Body;
            msg.Subject = "Message du Form de contact";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("nicolas63renault@gmail.com", "password");

            try
            {
                smtpClient.Send(msg);
                ViewBag.ContactMessage = "Message Envoyé !";
            }
            catch (Exception ex)
            {
                ViewBag.ContactMessage = "Une erreur est survenue !"+ ex.Message;
            }

            return View(Form);
        }
    }
}