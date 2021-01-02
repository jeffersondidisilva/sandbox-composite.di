using Sandbox.Composite.DI.API.Entities;

namespace Sandbox.Composite.DI.API.Services
{
    public interface INotificationService
    {
        void Notify(Person person);
    }
}