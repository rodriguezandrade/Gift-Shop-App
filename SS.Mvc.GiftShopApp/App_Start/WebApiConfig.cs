using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Validation.Providers;

using System.Web.Http.ExceptionHandling;
using SS.Logging.NLog;
using SS.Web.Http.ExceptionHandling;
using System.Web.Http.Cors;
using SS.Mvc.GiftShopApp.Controllers.LoginJWT;

namespace SS.Mvc.GiftShopApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Web Api config Services
            config.EnableCors(new EnableCorsAttribute("http://localhost:54467", headers: "*", methods: "*"));

        // Attribute routing.
        config.MapHttpAttributeRoutes();

            // There can be multiple exception loggers. (By default, no exception loggers are registered.)
            config.Services.Add(typeof(IExceptionLogger), new SsExceptionLogger { Logger = new NLogLogFacade(typeof(SsExceptionLogger)) });
            config.MessageHandlers.Add(new TokenValidationHandler());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            ConfigureFormatter(config);

            ConfigureSerializer(config);
        }

        private static void ConfigureFormatter(HttpConfiguration config)
        {
            // Remove the XmlFormatter
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);
        }

        private static void ConfigureSerializer(HttpConfiguration config)
        {
            var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var resolver = settings.ContractResolver as DefaultContractResolver;
            if (resolver != null)
            {
                resolver.IgnoreSerializableAttribute = true;
            }

            //var defaultSettings = new JsonSerializerSettings();

            config.Services.RemoveAll(
                typeof(System.Web.Http.Validation.ModelValidatorProvider),
                v => v is InvalidModelValidatorProvider);
        }
    }
}