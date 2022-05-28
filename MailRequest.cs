using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace DisneyAPI
{
    public class MailRequest
    {
        public void SendMail()
        {
            string Servidor = "smtp.gmail.com";
            int Puerto = 587;
            String GmailUser = "fresh.drunk@gmail.com";
            String GmailPass = "igFresh0101";

            MimeMessage mensaje = new();
            mensaje.From.Add(new MailboxAddress("Pruebas", GmailUser));
            mensaje.To.Add(new MailboxAddress("Destino", GmailUser));
            mensaje.Subject = "Hola desde C# con MailKit";

            BodyBuilder CuerpoMensaje = new();
            CuerpoMensaje.TextBody = "Hola";
            CuerpoMensaje.HtmlBody = "Hola <b> Mundo </b>";

            mensaje.Body = CuerpoMensaje.ToMessageBody();

            SmtpClient ClienteSmtp = new();
            ClienteSmtp.CheckCertificateRevocation = false;
            ClienteSmtp.Connect(Servidor, Puerto, MailKit.Security.SecureSocketOptions.StartTls);
            ClienteSmtp.Authenticate(GmailUser, GmailPass);
            ClienteSmtp.Send(mensaje);
            ClienteSmtp.Disconnect(true);

        }
    }
}
