﻿using RazorEngine;
using RazorEngine.Templating;
using System.Web;

namespace Jt.SingleService.Lib.Utils
{
    public class CHelperRazorEngine
    {
        public static string CodeGenerateRazorEngine<T>(string key, string template, T model)
        {
            string content = Engine.Razor.RunCompile(template, key, typeof(T), model);
            return HtmlCharacterEscape(content);
        }

        public static string HtmlCharacterEscape(string html)
        {
            return HttpUtility.HtmlDecode(html);
        }
    }
}
