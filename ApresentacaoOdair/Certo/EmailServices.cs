namespace ApresentacaoOdair
{
    public static class EmailService
    {
        public static void Enviar(string de, string para, string assunto, string texto)
        {
            var mail = new MailMessage(de, para);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = assunto;
            mail.Body = texto;
            client.Send(mail);  
        }
    }
}