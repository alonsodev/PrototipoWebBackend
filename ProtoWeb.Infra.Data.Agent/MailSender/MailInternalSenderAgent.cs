using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;


namespace ProtoWeb.Infra.Data.Agent.MailSender
{
    public class MailInternalSenderAgent : IMailInternalSenderAgent
    {
        private string userName;
        private string password;
        private string hostName;
        private int port;
        private bool enableSsl;
        private bool useDefaultCredentials;

        public MailInternalSenderAgent(string hostName, int port, bool enableSsl, bool useDefaultCredentials, string userName, string password)
        {
            //if (string.IsNullOrWhiteSpace(hostName)) throw new ArgumentException("hostName");
            if (port <= 0) throw new ArgumentException("port");
            this.hostName = hostName;
            this.userName = userName;
            this.password = password;
            this.enableSsl = enableSsl;
            this.useDefaultCredentials = useDefaultCredentials;
            this.port = port;
        }

        public async Task EnviarCorreoAsync(MailDto correo)
        {
            if (string.IsNullOrWhiteSpace(correo.Asunto)) throw new ArgumentNullException("correo.Asunto");
            if (string.IsNullOrWhiteSpace(correo.Cuerpo)) throw new ArgumentNullException("correo.Cuerpo");
            if (correo.Para == null || correo.Para.Count <= 0) throw new ArgumentNullException("correo.Para");

            var correoDe = userName;
            var correoDisplay = correo.DeDisplay ?? correoDe;
            using (var smtpClient = new SmtpClient(hostName, port))
            {
                smtpClient.EnableSsl = enableSsl;
                smtpClient.UseDefaultCredentials = useDefaultCredentials;
                if (!useDefaultCredentials)
                    smtpClient.Credentials = new NetworkCredential(userName, password);

                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(correoDe, correoDisplay);
                    mailMessage.Subject = correo.Asunto;
                    mailMessage.Body = correo.CuerpoEsHtml ? WebUtility.HtmlDecode(correo.Cuerpo) : correo.Cuerpo;
                    mailMessage.IsBodyHtml = correo.CuerpoEsHtml;

                    foreach (var item in correo.Para)
                    {
                        mailMessage.To.Add(new MailAddress(item.Key, item.Value ?? item.Key));
                    }
                    if (correo.Cc != null && correo.Cc.Count > 0)
                        foreach (var item in correo.Cc)
                        {
                            mailMessage.CC.Add(new MailAddress(item.Key, item.Value ?? item.Key));
                        }
                    if (correo.Adjuntos != null && correo.Adjuntos.Count > 0)
                        foreach (var item in correo.Adjuntos)
                        {

                            Stream stream = new MemoryStream(item.ArchivoAsBytes);
                            var adjunto = new Attachment(stream, new ContentType(item.MimeType));
                            mailMessage.Attachments.Add(adjunto);
                        }
                    await smtpClient.SendMailAsync(mailMessage);
                    //Liberar adjuntos
                    foreach (var attachment in mailMessage.Attachments)
                    {
                        attachment.ContentStream.Dispose();
                        attachment.Dispose();
                    }
                }
            }
        }
    }
}