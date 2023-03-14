using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Lib.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        public static bool IsNotNullOrWhiteSpace(this string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }
    }
}
