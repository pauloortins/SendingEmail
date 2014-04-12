using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using SendingEmail.Models;

namespace SendingEmail.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendEmail(EmailModel email)
        {
            /*
             * This config, when in a production code should be placed in the app config, in this way,
             * you can change the config without have to change and recompile the code
             */

            const string fromEmail = "Your email's address";
            const string fromPassword = "Your password";            

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail, fromPassword)
            };

            var message = new MailMessage(
                from: fromEmail,
                to: email.To,
                subject: email.Subject,
                body: email.Body);
            
            smtp.Send(message);            

            return View("Index");
        }

    }
}
