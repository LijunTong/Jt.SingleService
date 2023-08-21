using Jt.SingleService.Core;
using Jt.SingleService.Data;
using Jt.Common.Tool.DI;
using Jt.Common.Tool.Extension;
using Jt.Common.Tool.Helper;
using Action = Jt.SingleService.Data.Action;
namespace Jt.SingleService.Service
{
    public class MenuSvc : BaseSvc<Menu>, IMenuSvc, ITransientDIInterface
    {
        private readonly IMenuRepo _repository;
        private readonly IMenuCacheSvc _menuCacheSvc;
        private readonly IActionSvc _actionSvc;
        private readonly IMainCacheSvc _mainCacheSvc;
        private readonly IUserRoleSvc _userRoleSvc;
        private readonly IRoleSvc _roleSvc;
        private readonly IRoleActionRepo _roleActionRepo;

        public MenuSvc(IMenuRepo repository, IMenuCacheSvc menuCacheSvc, IActionSvc actionSvc, IMainCacheSvc mainCacheSvc, IUserRoleSvc userRoleSvc, IRoleSvc roleSvc, IRoleActionRepo roleActionRepo) : base(repository)
        {
            _repository = repository;
            _menuCacheSvc = menuCacheSvc;
            _actionSvc = actionSvc;
            _mainCacheSvc = mainCacheSvc;
            _userRoleSvc = userRoleSvc;
            _roleSvc = roleSvc;
            _roleActionRepo = roleActionRepo;
        }

        public async Task BindMenuAndControllerAsync(Menu menu)
        {
            var exists = await _repository.GetFirstAsync(x => x.Path == menu.Path);
            if (exists != null)
            {
                exists.Controller = menu.Controller;
                exists.Title = menu.Title;
                await _repository.UpdateAsync(exists);
                await _repository.SaveAsync();
            }
            else
            {
                menu = menu.FillEmptyString();
                await _repository.InsertAsync(menu);
                await _repository.SaveAsync();
            }
        }

        public async Task<ApiResponse<List<Menu>>> GetBackMenuAsync(string userId)
        {
            // 这里把前后台菜单一起获取
            var menus = await _repository.GetListAsync(x => x.IsDel == 0);
            var roles = await _roleSvc.GetRolesAsync(userId);
            if (roles.Data.Any(x => x.Code == EnumRole.Admin.ToString()))
            {
                var data1 = await GetMenuTreeAsync("", menus);
                return ApiResponse<List<Menu>>.Succeed(data1);
            }
            var roleIds = roles.Data.Select(x => x.Id).ToList();
            var userPermissions = await _roleActionRepo.GetListAsync(x => roleIds.Contains(x.RoleId));
            var roleAction = userPermissions.Where(x => roles.Data.Any(r => r.Id == x.RoleId) && x.Action == EnumAction.Display.ToString());//角色对应菜单展示的权限
            menus = menus.Where(x => roleAction.Any(r => r.Controller == x.Controller || r.Controller == x.Name)).ToList();
            var data = await GetMenuTreeAsync("", menus);
            return ApiResponse<List<Menu>>.Succeed(data);
        }

        public async Task<ApiResponse<List<string>>> GetControllerAsync()
        {
            var data = await _menuCacheSvc.GetControllerAsync();
            return ApiResponse<List<string>>.Succeed(data);
        }

        public async Task<ApiResponse<List<Menu>>> GetFrontMenuAsync()
        {
            var menus = await _repository.GetListAsync(x => x.Type == (int)EnumMenuType.Front);
            var data = await GetMenuTreeAsync("", menus);
            return ApiResponse<List<Menu>>.Succeed(data);
        }

        public async Task<ApiResponse<Menu>> GetMenuAsync(string path)
        {
            var data = await _repository.GetFirstAsync(x => x.Path == path);
            return ApiResponse<Menu>.Succeed(data);
        }

        public async Task<ApiResponse<List<Menu>>> GetMenuTreeWithActionAsync()
        {
            var data = await GetMenuTreeWithActionAsync("");
            return ApiResponse<List<Menu>>.Succeed(data);
        }

        private async Task<List<Menu>> GetMenuTreeWithActionAsync(string parentId)
        {
            List<Menu> roots = (await _repository.GetListAsync(x => x.ParentId == parentId && x.IsDel == 0)).OrderBy(x => x.SortIndex).ToList();
            foreach (var item in roots)
            {
                item.Actions = (await _actionSvc.GetActionsAsync(item.Controller)).Data;
                item.Actions.Insert(0, new Action
                {
                    Controller = (item.Controller == "无" || string.IsNullOrWhiteSpace(item.Controller) ? item.Name : item.Controller),
                    Name = EnumAction.Display.ToString(),
                    Text = EnumHelper.GetEnumDesp(typeof(EnumAction), (int)EnumAction.Display)
                });
                item.Children = await GetMenuTreeWithActionAsync(item.Id);
            }
            return roots;
        }

        public async Task InitControllerAsync(Type type)
        {
            List<string> controllers = new List<string>();
            var controllerTypes = AssemblyHelper.GetDerived(AppDomain.CurrentDomain.GetAssemblies(), type);
            controllerTypes.ForEach(x => controllers.Add(x.Name));
            await _menuCacheSvc.SetControllerAsync(controllers);
        }

        public async Task InsertMenuAsync(Menu menu)
        {
            await _repository.InsertAsync(menu);
            await _repository.SaveAsync();
        }

        public async Task<ApiResponse<bool>> IsExistsMenuAsync(Menu menu)
        {
            var existsMenu = await _repository.GetMenuByNameAsync(menu.Name);
            if (menu.Id.IsNotNullOrWhiteSpace() && existsMenu != null && existsMenu.Id == menu.Id)
            {
                return ApiResponse<bool>.Succeed(false);
            }

            var data = existsMenu != null;
            return ApiResponse<bool>.Succeed(data);
        }

        public async Task UpdateMenuAsync(Menu menu)
        {
            await _repository.UpdateAsync(menu);
            await _repository.SaveAsync();
        }

        private async Task<List<Menu>> GetMenuTreeAsync(string parentId, List<Menu> menus)
        {
            List<Menu> roots = menus.FindAll(x => x.ParentId == parentId).OrderBy(x => x.SortIndex).ToList();
            if (roots != null && roots.Count > 0)
            {
                foreach (var item in roots)
                {
                    item.Children = await GetMenuTreeAsync(item.Id, menus);
                }
            }
            return roots;
        }
    }
}
