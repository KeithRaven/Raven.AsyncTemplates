using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using Orchard;

namespace Morphous.AsyncTemplates.Services
{
    public interface IAsyncTemplateProvider : IDependency
    {
        string Identifier { get; }
        string GetTemplateUrl(RequestContext context, string ContentType, string displayType);
    }
}
