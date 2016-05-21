using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard;
using Orchard.DisplayManagement.Descriptors;
using Orchard.Mvc;
using Raven.Api;

namespace Raven.AsyncTemplates.Controllers
{
    public class TemplatesController : Controller
    {
        private readonly IOrchardServices _services;
        private readonly IBindingTypeCreateAlterations _alterations;

        public TemplatesController(
            IOrchardServices services,
            IBindingTypeCreateAlterations alterations) {
            _services = services;
            _alterations = alterations;
        }

        // GET: Templates
        public ActionResult Index(string contentType, string templateType ,string displayType = "Summary")
        {
            var model = _services.ContentManager.New(contentType);

            dynamic vm;
            using (_alterations.CreateScope(templateType)) {
                vm = _services.ContentManager.BuildDisplay(model, displayType);
            }
           
            return View(vm);
        }
    }
}