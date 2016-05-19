using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard;
using Orchard.DisplayManagement.Descriptors;
using Orchard.Mvc;

namespace Raven.AsyncTemplates.Controllers
{
    public class TemplatesController : Controller
    {
        private readonly IOrchardServices _services;

        public TemplatesController(
            IOrchardServices services) {
            _services = services;
        }

        // GET: Templates
        public ActionResult Index(string contentType, string templateType ,string displayType = "Summary")
        {
            var model = _services.ContentManager.New(contentType);
            var vm = _services.ContentManager.BuildDisplay(model, displayType, bindingType: templateType);
            return View(vm);
        }
    }
}