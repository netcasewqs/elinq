using System;
using System.Linq;
using System.Xml.Linq;

namespace NLite.Data
{


    static class XmlExtensions
    {
        public static T GetAttributeValue<T>(this XElement e, string name)
        {
            if (e.Attribute(name) != null)
                return Converter.Convert<string, T>(e.Attribute(name).Value);

            var attr = e.Attributes().FirstOrDefault(p => string.Equals(p.Name.LocalName, name, StringComparison.InvariantCultureIgnoreCase));

            if (attr == null)
                return default(T);
            return Converter.Convert<string, T>(attr.Value);
        }
    }
}
