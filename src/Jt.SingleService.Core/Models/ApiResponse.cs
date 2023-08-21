using Newtonsoft.Json;

namespace Jt.SingleService.Core
{
    public class ApiResponse<T>
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        public static ApiResponse<T> Succeed(T data, string msg = "操作成功")
        {
            return new ApiResponse<T>
            {
                Code = ApiReturnCode.Succeed,
                Msg = msg,
                Data = data
            };
        }

        public static ApiResponse<T> Fail(int code, string msg = "操作失败")
        {
            return new ApiResponse<T>
            {
                Code = code,
                Msg = msg,
                Data = default
            };
        }

        public static ApiResponse<T> ParamError(string msg)
        {
            return new ApiResponse<T>
            {
                Code = ApiReturnCode.ParamError,
                Msg = msg,
                Data = default
            };
        }

        public static ApiResponse<T> SystemError(string msg)
        {
            return new ApiResponse<T>
            {
                Code = ApiReturnCode.SystemError,
                Msg = msg,
                Data = default
            };
        }

        public static ApiResponse<T> OperationFail(string msg)
        {
            return new ApiResponse<T>
            {
                Code = ApiReturnCode.OperationFail,
                Msg = msg,
                Data = default
            };
        }

        public static ApiResponse<T> UnAuth()
        {
            return new ApiResponse<T>
            {
                Code = ApiReturnCode.UnAuth,
                Msg = "请先登录",
                Data = default
            };
        }


        public static ApiResponse<T> UnLogin()
        {
            return new ApiResponse<T>
            {
                Code = ApiReturnCode.UnLogin,
                Msg = "请先登录",
                Data = default
            };
        }

        public static ApiResponse<T> Forbidden()
        {
            return new ApiResponse<T>
            {
                Code = ApiReturnCode.Forbidden,
                Msg = "请先登录",
                Data = default
            };
        }
    }
}
