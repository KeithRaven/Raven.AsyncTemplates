using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Morphous.AsyncTemplates.Extensions;

namespace Morphous.AsyncTemplates.Utility
{
    public static class AngularHelpers
    {

        private static string _prefix = "Model";

        public static string PathForPart(dynamic model, params string[] path) {
            return AngularHelpers.Path((ContentPart)model.ContentPart, path);
        }

        public static string PathForField(dynamic model, params string[] path) {
            return AngularHelpers.Path((ContentPart)model.ContentPart, (ContentField)model.ContentField, path);
        }

        public static string Path(ContentPart part, params string[] path) {
            return MakePath(_prefix, part.PartDefinition.Name, MakePath(path));
        }

        public static string Path(ContentPart part, ContentField field, params string[] path) {
            return MakePath(_prefix, part.PartDefinition.Name, field.Name, MakePath(path));
        }

        private static string MakePath(params string[] segments) {
            return string.Join(".", segments.Where(s => !string.IsNullOrEmpty(s)).Select(s => s.DropFirst()));
        }
    }
}