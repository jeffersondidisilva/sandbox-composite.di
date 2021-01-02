using Microsoft.Extensions.Logging;
using Sandbox.Composite.DI.API.Entities;

namespace Sandbox.Composite.DI.API.Services.Implementations
{
    public class PushService : INotificationService
    {
        private readonly ILogger<EmailService> _logger;

        public PushService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }
        
        public void Notify(Person person)
        {
            //Implement e-mail service
            _logger.LogInformation($"Sending push to {person.PushToken}");
        }
    }
}