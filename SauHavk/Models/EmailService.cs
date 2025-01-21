using MailKit.Net.Smtp;
using MimeKit;

public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SendEmail(string toEmail, string subject, string body)
    {
        var smtpServer = _configuration["EmailSettings:SmtpServer"];
        var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
        var username = _configuration["EmailSettings:Username"];
        var password = _configuration["EmailSettings:Password"];

        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Web Sitesi", username));
        emailMessage.To.Add(new MailboxAddress("Alıcı", toEmail));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart("plain")
        {
            Text = body
        };

        using (var client = new SmtpClient())
        {
            client.Connect(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
            client.Authenticate(username, password);
            client.Send(emailMessage);
            client.Disconnect(true);
        }
    }
}
