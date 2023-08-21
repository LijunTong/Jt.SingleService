using Jt.SingleService.Core;
using Jt.SingleService.Data;
namespace Jt.SingleService.Service
{
    public interface IUserSvc : IBaseSvc<User>
    {
        Task<ApiResponse<User>> GetUserByNameAsync(string userName);

        Task<ApiResponse<bool>> CheckUserNameExistsAsync(string userName);

        Task<ApiResponse<bool>> RegisterAsync(User user);

        Task<ApiResponse<GetUserInfoOutput>> GetUserInfoAsync(string id);


        Task<ApiResponse<GetPagerListOutput>> GetUserAsync(string id);

        Task<ApiResponse<PagerOutput<GetPagerListOutput>>> GetUserPagerAsync(GetPagerListReq req);
    }
}