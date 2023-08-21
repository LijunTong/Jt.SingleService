namespace Jt.SingleService.Core
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
