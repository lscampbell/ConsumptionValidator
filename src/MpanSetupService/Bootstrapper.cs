using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Nancy;
using Nancy.TinyIoc;
using Nancy.Configuration;
using LoggingService.Models;

namespace MpanSetupService
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        readonly IServiceProvider _serviceProvider;
        public Bootstrapper(IServiceProvider serviceProvider) 
            => _serviceProvider = serviceProvider;

        public override void Configure(INancyEnvironment environment) 
            => environment.Tracing(true, true);

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(_serviceProvider.GetService<ILoggerFactory>());
            container.Register(_serviceProvider.GetService<ServiceClient<LogRequest, LogResponse>>());
        }
    }
}