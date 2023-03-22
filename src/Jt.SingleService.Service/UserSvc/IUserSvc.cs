using Jt.SingleService.Core.Models;
using Jt.SingleService.Data.Dto;
using Jt.SingleService.Data.Dto.User.Output;
using Jt.SingleService.Data.Dto.User.Req;
using Jt.SingleService.Data.Tables;

namespace Jt.SingleService.Service.UserSvc
{
    public interface IUserSvc : IBaseSvc<User>
    {
        Task<User> GetUserByNameAsync(string userName);

        Task<bool> CheckUserNameExistsAsync(string userName);

        Task<ApiResponse<bool>> RegisterAsync(User user);

        Task<GetUserInfoOutput> GetUserInfoAsync(string id);


        Task<ApiResponse<GetPagerListOutput>> GetUserAsync(string id);

        Task<ApiResponse<PagerOutput>> GetUserPagerAsync(GetPagerListReq req);
    }
}