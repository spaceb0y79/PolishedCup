using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace PolishedCup
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                 name: "ActionApi",
                 routeTemplate: "{controller}/{id}/{action}",
                 defaults: new { id = string.Empty }
             );

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}", //{action}  route by method
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
