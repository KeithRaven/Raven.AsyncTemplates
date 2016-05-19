using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Raven.AsyncTemplates.Services.Providers
{
    public class AngularAsyncTemplateProvider : IAsyncTemplateProvider
    {
        public string Identifier { get { return "Angular"; } }
            

        public string GetTemplateUrl(RequestContext context, string ContentType, string displayType)
        {
            UrlHelper urlHelper = new UrlHelper(context);
            return urlHelper.Action("Index", "Templates", new { area = "Raven.AsyncTemplates", contentType = ContentType, displayType = displayType, templateType = "Angular" });
        }
    }
}