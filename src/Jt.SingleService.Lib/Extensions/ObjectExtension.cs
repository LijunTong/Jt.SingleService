using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Lib.Extensions
{
    public static class ObjectExtension
    {
        public static string ToJosn<T>(this T t) where T : class
        {
            IsoDateTimeConverter isoDateTimeConverter = new IsoDateTimeConverter();
            isoDateTimeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            return JsonConvert.SerializeObject(t, Formatting.Indented, isoDateTimeConverter);
        }

        public static T ToObj<T>(this string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string JoinBySeparator<T>(this List<T> lst, Func<T, string> selector, string split)
        {
            return string.Join(split, lst.Select(selector));
        }
    }
}
