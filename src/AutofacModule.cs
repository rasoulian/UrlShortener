using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using UrlShortener.Web.Services;

namespace UrlShortener.Web
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the services.AddAutofac() that happens in Program and registers Autofac
            // as the service provider.
            builder.Register(c => new ShortensService(
                    c.Resolve<IConfiguration>(),
                    c.Resolve<ILogger<ShortensService>>()))
                .As<IShortensService>()
                .InstancePerLifetimeScope();


        }
    }
}
