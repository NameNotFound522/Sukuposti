using SendGrid.Helpers.Mail;

namespace Sukuposti.Application.Options;

public class EmailOptions
{
    public EmailAddress From { get; set; }
    public EmailAddress To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}