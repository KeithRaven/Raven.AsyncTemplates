using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Morphous.AsyncTemplates
{
    public class Routes : IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
                new RouteDescriptor {
                    Name="AngularTemplate",
                    Priority = 1,
                    Route = new Route(
                        "Templates/{templateType}/{contentType}/{displayType}",
                        new RouteValueDictionary {
                            {"area", "Morphous.AsyncTemplates"},
                            {"controller", "Templates"},
                            {"action", "Index"},
                            { "displayType", "Detail"}
                        },
                        new RouteValueDictionary {
                        },
                        new RouteValueDictionary {
                            {"area", "Morphous.AsyncTemplates"}
                        },
                        new MvcRouteHandler())
                }
            };
        }

    }
}