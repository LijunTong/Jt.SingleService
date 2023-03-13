using Jt.SingleService.Core.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ActionAttribute : Attribute, IFilterMetadata
    {
        public string Text { get; set; }

        public EnumActionType ActionType { get; set; }

        public ActionAttribute(string text, EnumActionType actionType)
        {
            this.Text = text;
            this.ActionType = actionType;
        }
    }
}
