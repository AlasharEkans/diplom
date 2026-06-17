using BL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL.Services;

public class EmailService(IConfiguration configuration) : IEmailService
{
    private readonly string _smtpServer = configuration["EmailSettings:SmtpServer"] ?? "localhost";

    public Task SendEmailAsync(string toEmail, string subject, string message)
    {
        System.Diagnostics.Debug.WriteLine($"Email sent to {toEmail} with subject '{subject}': {message}");
        return Task.CompletedTask;
    }
}