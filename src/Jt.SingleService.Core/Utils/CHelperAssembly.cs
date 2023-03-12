using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Utils
{
    public class CHelperAssembly
    {
        public static List<MethodInfo> GetMethodInfos(Assembly assembly)
        {
            List<MethodInfo> methodInfos = new List<MethodInfo>();
            foreach (var type in assembly.GetTypes())
            {
                methodInfos.AddRange(GetMethodInfos(type));
            }
            return methodInfos;
        }

        public static List<MethodInfo> GetMethodInfos(Type type)
        {
            return type.GetMethods().ToList();
        }

        public static List<MethodInfo> GetMethodInfosWithAttribute(Assembly assembly, Type attributeType)
        {
            List<MethodInfo> methodInfos = new List<MethodInfo>();
            foreach (var type in assembly.GetTypes())
            {
                methodInfos.AddRange(GetMethodInfosWithAttribute(type, attributeType));
            }
            return methodInfos;
        }
        public static List<MethodInfo> GetMethodInfosWithAttribute(Type type, Type attributeType)
        {
            return type.GetMethods().Where(x => x.CustomAttributes.Any(x => x.AttributeType == attributeType)).ToList();
        }

        public static List<Type> GetDerived(Assembly assembly, Type type)
        {
            return assembly.GetTypes().Where(x => x.BaseType == type).ToList();
        }

        public static List<Type> GetTypesByAttribute(Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(x => x.CustomAttributes.Any(a => a.AttributeType == type));
            return types.ToList();
        }
    }
}
