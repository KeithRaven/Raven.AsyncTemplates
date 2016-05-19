using Orchard;
using Orchard.ContentManagement;
using Orchard.DisplayManagement;
using Orchard.DisplayManagement.Descriptors;
using Orchard.DisplayManagement.Implementation;
using Orchard.Environment;
using Raven.AsyncTemplates.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raven.AsyncTemplates.Shapes
{
    public class TemplateShapeAlterations : IShapeTableProvider
    {
        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly Work<IEnumerable<IAsyncTemplateProvider>> _templateProviders;

        public TemplateShapeAlterations(
            IWorkContextAccessor workContextAccessor,
            Work<IEnumerable<IAsyncTemplateProvider>> templateProviders) {
            _workContextAccessor = workContextAccessor;
            _templateProviders = templateProviders;
        }


        public void Discover(ShapeTableBuilder builder) {
            builder.Describe("Content").OnDisplaying(created => {
                if (created.Shape.Metadata.BindingType == "Translate") {
                    var templatesShape = _workContextAccessor.GetContext().Resolve<IShapeFactory>().Create("Templates");
                    templatesShape.Metadata.DisplayType = created.Shape.Metadata.DisplayType;

                    //we're out of the builddisplay context so need to set this manually
                    templatesShape.Metadata.BindingType = "Translate";
                    ((dynamic)templatesShape).ContentItem = created.Shape.ContentItem;
                    created.Shape.Meta.Add(templatesShape, "0");
                }

            });
        }

        [Shape(bindingType: "Translate")]
        public void Templates(dynamic Display, dynamic Shape) {
            if (_templateProviders.Value.Any()) {

                using (Display.ViewDataContainer.Model.Node("templates")) {

                    _templateProviders.Value.ToList().ForEach(tp => Display.ViewDataContainer.Model.Set(tp.Identifier, tp.GetTemplateUrl(_workContextAccessor.GetContext().HttpContext.Request.RequestContext, Shape.ContentItem.ContentType, Shape.Metadata.DisplayType)));

                }
            }
        }
    }
}