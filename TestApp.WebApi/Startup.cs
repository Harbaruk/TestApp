using LightInject;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using TestApp.DataAccess;
using TestApp.DataAccess.Context;
using TestApp.Operations.Abstraction;
using TestApp.Operations.Implementation;

[assembly: OwinStartup(typeof(TestApp.WebApi.Startup))]

namespace TestApp.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureWebApi(config);
            ServiceContainer container = ConfigureDependencyResolver(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private static void ConfigureWebApi(HttpConfiguration config)
        {
            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private static ServiceContainer ConfigureDependencyResolver(HttpConfiguration httpConfig)
        {
            var container = new ServiceContainer();

            container.Register<AppContext, AppContext>(new PerRequestLifeTime());
            container.Register<IUnitOfWork, UnitOfWork>(new PerRequestLifeTime());
            container.Register(typeof(IRepository<>), typeof(Repository<>), new PerRequestLifeTime());

            container.Register<IPhonesOperations, PhonesOperations>(new PerRequestLifeTime());

            container.RegisterApiControllers(typeof(ApiControllerBase).Assembly);
            container.EnableWebApi(httpConfig);
            return container;
        }

    }
}
