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

[assembly: OwinStartup(typeof(Books.Api.Startup))]

namespace Books.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);



            var dataSeed = new DataSeed();
            dataSeed.Seed();
        }
    }
}
