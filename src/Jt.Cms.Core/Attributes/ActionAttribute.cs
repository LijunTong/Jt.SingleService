using Microsoft.AspNetCore.Mvc.Filters;

namespace Jt.Cms.Core
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
