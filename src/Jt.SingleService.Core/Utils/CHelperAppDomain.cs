using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Utils
{
    public class CHelperAppDomain
    {
        public static string GetBaseDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string CombineWithBaseDirectory(params string[] paths)
        {
            string path = GetBaseDirectory();
            for (int i = 0; i < paths.Length; i++)
            {
                path = Path.Combine(GetBaseDirectory(), paths[i]);
            }
            return path;
        }
    }
}
