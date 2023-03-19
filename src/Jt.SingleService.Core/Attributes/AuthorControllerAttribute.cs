using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class AuthorControllerAttribute : Attribute
    {
        public string Text { get; set; }

        public AuthorControllerAttribute(string text)
        {
            this.Text = text;
        }

        public AuthorControllerAttribute()
        {
        }
    }
}
