using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Books.Business;
using Microsoft.Owin.Cors;
using System.Net.Http.Formatting;
using System.Linq;
using Newtonsoft.Json.Serialization;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using Books.Api.Services;
using Books.Entities;
using Books.Api.ViewModels;

[assembly: OwinStartup(typeof(Books.Api.Startup))]

namespace Books.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            var builder = new ContainerBuilder();
            RegisterAutofac(builder);
            var container = builder.Build();

            ConfigRoutes(config);
            ConfigAutofacContainer(config, container);
            ConfigJsonFormatter(config);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);

            SeedInitialData();
        }

        private void RegisterAutofac(ContainerBuilder builder)
        {
            // Register Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register custom
            builder.RegisterModule(new Business.AutofacModule());
            builder.RegisterType<AuthorToAuthorVmConverter>().As<IConverter<Author, AuthorVm>>().SingleInstance();
            builder.RegisterType<BookToBookVmConverter>().As<IConverter<Book, BookVm>>().SingleInstance();
            builder.RegisterType<PublisherToPublisherVmConverter>().As<IConverter<Publisher, PublisherVm>>().SingleInstance();
        }

        private void ConfigRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private void ConfigAutofacContainer(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private void ConfigJsonFormatter(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private void SeedInitialData()
        {
            var dataSeed = new DataSeed();
            dataSeed.Seed();
        }
    }
}
