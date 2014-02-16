using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMCServiceCenter.Web.UI
{
    public class MarkupList<T> : List<T>
    {
        public override string ToString()
        {
            var value = string.Concat("<ul>");
            foreach (T member in this)
            {
                value = string.Concat(value, "<li>", member.ToString(), "</li>");
            }
            return string.Concat(value, "</ul>");
        }

        public static MarkupList<T> Convert(List<T> list)
        {
            var value = new MarkupList<T>();
            value.AddRange(list);
            return value;
        }
    }
}