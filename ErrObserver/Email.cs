using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Security;
using System.Net.Mime;

namespace ErrObserver
{
    class Email : IEmail
    {
        public string body { get; private set; }
        public string To { get; private set; }
        public int SMTPPort { get; private set; }
        public string Host { get; private set; }
        public string Subject { get; private set; }
        public bool EnableSsl { get; private set; }
        NetworkCredential credential;
        //================================================
        public Email(ref string addr, ref SecureString password)
        {
            Subject = "Wykryto błąd w dniu " + DateTime.Now;
            credential = new NetworkCredential(addr, password);
        }

        public void addSMTPPort(ref int port)
        {
            this.SMTPPort = port;
        }

        public void addSMTPHost(ref string host)
        {
            this.Host = host;
        }

        public void addTo(ref string to)
        {
            this.To = to;
        }

        public void addSSL(ref bool enableSSL)
        {
            this.EnableSsl = enableSSL;
        }
        //================================================
        public void send(string dirPath, string filePath)
        {
            body = String.Format("" +
                "<h1>Witaj</h1><p>Wykryto nowy element w katologu <span style='color: red;'>{0}</span></p>" +
                "<p style='font-weigth: 600;'>Więcej szczegółów w załączniku</p>", dirPath);
            var smtpClient = new SmtpClient() {
                Port = this.SMTPPort,
                Host = this.Host,
                Credentials = credential,
                EnableSsl = this.EnableSsl
            };
            var message = new MailMessage()
            {
                From = new MailAddress(credential.UserName),
                Subject = this.Subject,
                Body = body,
                IsBodyHtml = true
            };
            
            message.To.Add(this.To);
            var attachment = new Attachment(filePath, MediaTypeNames.Text.Plain);
            message.Attachments.Add(attachment);
            smtpClient.Send(message);
        }
    }
}
