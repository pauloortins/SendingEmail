SendingEmail
============

Example of using C# to build a form to send emails.



This config is to send emails through Gmail, to send thought another provider we need to check their server configuration.

```c#

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

```
