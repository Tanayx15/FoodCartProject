using System.Net.Mail;
using System.Threading.Tasks;

public class EmailService
{
    private readonly string _smtpServer;
    private readonly int _port;
    private readonly string _username;
    private readonly string _password;
    private readonly string _fromAddress;

    public EmailService(string smtpServer, int port, string username, string password, string fromAddress)
    {
        _smtpServer = smtpServer;
        _port = port;
        _username = username;
        _password = password;
        _fromAddress = fromAddress;
    }

    public async Task SendEmailAsync(string toAddress, string subject, string htmlMessage)
    {
        var message = new MailMessage
        {
            From = new MailAddress(_fromAddress),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true
        };
        message.To.Add(toAddress);

        using (var client = new SmtpClient(_smtpServer, _port))
        {
            client.Credentials = new System.Net.NetworkCredential(_username, _password);
            client.EnableSsl = true;
            await client.SendMailAsync(message);
        }
    }
}
