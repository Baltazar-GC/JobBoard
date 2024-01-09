using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace backend.Services.Implementations
{
    public class MailService
    {
        private readonly IStudentExtraDataService _studentExtraDataService;


        string From = "bolsatrabajo.utn@gmail.com"; //de quien procede, puede ser un alias

        string DE = "bolsatrabajo.utn@gmail.com"; //nuestro usuario de smtp
        string PASS = "oijrmxjukhuejano"; //nuestro password de smtp

        System.Net.Mail.MailMessage Email;

        public string error = "";

        public MailService(IStudentExtraDataService studentExtraDataService)
        {
            _studentExtraDataService = studentExtraDataService;
        }


        public bool enviaMail(string emailReceiver, string Message, string Subject, string userId)
        {

            if (emailReceiver.Trim().Equals("") || Message.Trim().Equals("") || Subject.Trim().Equals(""))
            {
                error = "El mail, el asunto y el mensaje son obligatorios";
                return false;
            }

            try
            {

                Email = new System.Net.Mail.MailMessage(From, emailReceiver, Subject, Message);
                var cv = _studentExtraDataService.GetStudentExtraData(userId);



                Email.Attachments.Add(new Attachment(new MemoryStream(cv.Curriculum), "Curriculum", "application/pdf"));


                Email.IsBodyHtml = true;
                Email.From = new MailAddress(From);


                System.Net.Mail.SmtpClient smtpMail = new System.Net.Mail.SmtpClient("smtp.gmail.com");

                smtpMail.EnableSsl = true;
                smtpMail.UseDefaultCredentials = false;
                smtpMail.Host = "smtp.gmail.com";
                smtpMail.Port = 587;
                smtpMail.Credentials = new System.Net.NetworkCredential(DE, PASS);

                smtpMail.Send(Email);

                smtpMail.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                error = "Ocurrio un error: " + ex.Message;
                return false;
            }

            return false;

        }
    }
}
