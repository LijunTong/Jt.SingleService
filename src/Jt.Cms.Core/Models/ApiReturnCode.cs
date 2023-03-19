using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.Cms.Core.Models
{
    public class ApiReturnCode
    {
        public static int Succeed => 1;

        public static int OperationFail => 0;

        public static int ParamError => 1001;

        public static int UnAuth => 1401;

        public static int UnLogin => 1402;

        public static int Forbidden => 1403;

        public static int SystemError => 1999;
    }
}
