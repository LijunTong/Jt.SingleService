using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.Cms.Lib.Extensions
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

        public static TOut ObjValueCopy<TIn, TOut>(this TIn tin)
        {
            Type typeIn = typeof(TIn);
            Type typeOut = typeof(TOut);
            var tout = (TOut)Activator.CreateInstance(typeOut);
            foreach (var item in typeOut.GetProperties())
            {
                var propIn = typeIn.GetProperty(item.Name);
                if (propIn != null && propIn.PropertyType == item.PropertyType)
                {
                    item.SetValue(tout, propIn.GetValue(tin));
                }
            }
            return tout;
        }

        public static List<TOut> ObjsValueCopy<TIn, TOut>(this List<TIn> tins)
        {
            Type typeIn = typeof(TIn);
            Type typeOut = typeof(TOut);
            List<TOut> outs = new List<TOut>();
            var outProps = typeOut.GetProperties();
            foreach (var item in tins)
            {
                var tout = (TOut)Activator.CreateInstance(typeOut);
                foreach (var outProp in outProps)
                {
                    var propIn = typeIn.GetProperty(outProp.Name);
                    if (propIn != null && propIn.PropertyType == outProp.PropertyType)
                    {
                        outProp.SetValue(tout, propIn.GetValue(item));
                    }
                }
                outs.Add(tout);
            }
            return outs;
        }
        public static T ObjDeepCopy<T>(this T tin)
        {
            Type type = typeof(T);
            var tout = (T)Activator.CreateInstance(type);
            foreach (var item in type.GetProperties())
            {
                var propIn = type.GetProperty(item.Name);
                if (propIn != null && propIn.PropertyType == item.PropertyType)
                {
                    item.SetValue(tout, propIn.GetValue(tin));
                }
            }
            return tout;
        }

        public static T FillEmptyString<T>(this T t)
        {
            Type type = t.GetType();
            foreach (var item in type.GetProperties())
            {
                if (item.PropertyType == typeof(string))
                {
                    var value = item.GetValue(t);
                    if (value == null)
                    {
                        item.SetValue(t, "");
                    }
                }
            }
            return t;
        }
    }
}
