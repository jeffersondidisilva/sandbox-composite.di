using System;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Composite.DI.API.Entities;
using Sandbox.Composite.DI.API.Services;

namespace Sandbox.Composite.DI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        
        [HttpGet("/{id}")]
        public void Notify([FromRoute] int id)
        {
            //Implement repository
            var person = new Person
            {
                Id = id,
                Name = "Jefferson",
                Email = "email@gmail.com",
                Phone = "410000000000",
                PushToken = Guid.NewGuid().ToString().Replace("-", "")
            };
            
            _notificationService.Notify(person);
        }
    }
}
