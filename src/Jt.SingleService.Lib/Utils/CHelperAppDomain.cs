using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Lib.Utils
{
    public class CHelperAppDomain
    {
        public static string GetBaseDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string CombineWithCreate(params string[] paths)
        {
            string path = GetBaseDirectory();
            paths = paths.Prepend(path).ToArray();
            path = Path.Combine(paths);
            FileInfo fileInfo = new FileInfo(path);
            fileInfo.Directory.Create();
            return path;
        }
    }
}
