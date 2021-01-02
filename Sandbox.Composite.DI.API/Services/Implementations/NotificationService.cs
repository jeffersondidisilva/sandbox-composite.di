using System.Collections.Generic;
using System.Threading.Tasks;
using Sandbox.Composite.DI.API.Entities;

namespace Sandbox.Composite.DI.API.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly IEnumerable<INotificationService> _services;

        public NotificationService(IEnumerable<INotificationService> services)
        {
            _services = services;
        }
        
        public void Notify(Person person)
        {
            Parallel.ForEach(_services, service => 
                service.Notify(person));
        }
    }
}