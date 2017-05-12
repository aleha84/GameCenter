using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace GameCenter.Infrastructure
{
    public class Router
    {
        public static void GetRouter(IRouteBuilder rb)
        {
            rb.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}");

            rb.MapRoute(
                name: "defaultApi",
                template: "api/{controller}/{action}/{id?}");
        }
    }
}
