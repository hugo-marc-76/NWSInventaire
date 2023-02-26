using System.Net;
using System.Net.Mail;
using static System.Net.Mime.MediaTypeNames;

namespace PingEquipementCavasXpert.Classes
{
    public class MailService
    {

        public bool SendGmail(string titre, string text1, string text2, string studentEmail)
        {
            try
            {

                string LoadFile = System.IO.File.ReadAllText("./Html/NwsEmailTemplate.html");
                string AddTitle = LoadFile.Replace("##TITRE##", titre);
                string AddText1 = AddTitle.Replace("##TEXT1##", text1);
                string AddText2 = AddText1.Replace("##TEXT2##", text2);

                string fromMail = "h.marc@cavas.fr";
                string fromPassword = "edmoiefckciebidf";
                //string fromPassword = "fhtahhvvolfhtdaz";

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromMail);
                message.Subject = "Rappel Inventaire";
                message.To.Add(new MailAddress(studentEmail));
                message.Body = AddText2;
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                smtpClient.Send(message);
                return true;

            } catch { return false; }
        }


    }

}
