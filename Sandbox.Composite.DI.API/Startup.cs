using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sandbox.Composite.DI.API.Services;
using Sandbox.Composite.DI.API.Services.Implementations;

namespace Sandbox.Composite.DI.API
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<EmailService>();
            services.AddTransient<SmsService>();
            services.AddTransient<PushService>();
            
            services.AddTransient<INotificationService, NotificationService>(e =>
                new NotificationService(new INotificationService[]
                {
                    e.GetRequiredService<EmailService>(),
                    e.GetRequiredService<SmsService>(),
                    e.GetRequiredService<PushService>()
                }));
                
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Sandbox.Composite.DI.API", 
                        Version = "v1"
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sandbox.Composite.DI.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
