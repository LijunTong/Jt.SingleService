using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Models
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }

        public string Msg { get; set; }

        public T Data { get; set; }

        public static ApiResponse<T> GetSucceed(T data, string msg = "操作成功")
        {
            return new ApiResponse<T>
            {
                Code = ApiReturnCode.Succeed,
                Msg = msg,
                Data = data
            };
        }

        public static ApiResponse<T> GetFail(int code, string msg = "操作失败")
        {
            return new ApiResponse<T>
            {
                Code = code,
                Msg = msg,
                Data = default(T)
            };
        }
    }
}
