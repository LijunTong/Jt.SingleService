using Jt.SingleService.Core.Enums;
using Jt.SingleService.Lib.Extensions;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Lib.Utils;
using Jt.SingleService.Data.Repositories.Interface;
using Jt.SingleService.Service.ActionSvc;
using Jt.SingleService.Service.MainSvc;
using Jt.SingleService.Service.MenuSvc;
using Jt.SingleService.Service.RoleSvc;
using Jt.SingleService.Service.UserRoleSvc;
using System.Reflection;
using Action = Jt.SingleService.Data.Tables.Action;
using Jt.SingleService.Lib.DI;

namespace Jt.SingleService.Service.UserSvc
{
    public class MenuSvc : BaseSvc<Menu>, IMenuSvc, ITransientInterface
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
                menu = CHelperObject.FillEmptyString(menu);
                await _repository.InsertAsync(menu);
                await _repository.SaveAsync();
            }
        }

        public async Task<List<Menu>> GetBackMenuAsync(string userId)
        {
            var menus = await _repository.GetListAsync(x => x.Type == (int)EnumMenuType.Back);
            var roles = await _roleSvc.GetRolesAsync(userId);
            if (roles.Any(x => x.Code == EnumRole.Admin.ToString()))
            {
                return await GetMenuTreeAsync("", menus);
            }
            var roleIds = roles.Select(x => x.Id).ToList();
            var userPermissions = await _roleActionRepo.GetListAsync(x => roleIds.Contains(x.RoleId));
            var roleAction = userPermissions.Where(x => roles.Any(r => r.Id == x.RoleId) && x.Action == EnumAction.Display.ToString());//角色对应菜单展示的权限
            menus = menus.Where(x => roleAction.Any(r => r.Controller == x.Controller || r.Controller == x.Name)).ToList();
            return await GetMenuTreeAsync("", menus);
        }

        public async Task<List<string>> GetControllerAsync()
        {
            return await _menuCacheSvc.GetControllerAsync();
        }

        public async Task<List<Menu>> GetFrontMenuAsync()
        {
            var menus = await _repository.GetListAsync(x => x.Type == (int)EnumMenuType.Front);
            return await GetMenuTreeAsync("", menus);
        }

        public async Task<Menu> GetMenuAsync(string path)
        {
            return await _repository.GetFirstAsync(x => x.Path == path);
        }

        public async Task<List<Menu>> GetMenuTreeWithActionAsync()
        {
            return await GetMenuTreeWithActionAsync("");
        }

        private async Task<List<Menu>> GetMenuTreeWithActionAsync(string parentId)
        {
            List<Menu> roots = (await _repository.GetListAsync(x => x.ParentId == parentId)).OrderBy(x => x.SortIndex).ToList();
            foreach (var item in roots)
            {
                item.Actions = await _actionSvc.GetActionsAsync(item.Controller);
                item.Actions.Insert(0, new Action
                {
                    Controller = (item.Controller == "无" || string.IsNullOrWhiteSpace(item.Controller) ? item.Name : item.Controller),
                    Name = EnumAction.Display.ToString(),
                    Text = CHelperEnum.GetEnumDesp(typeof(EnumAction), (int)EnumAction.Display)
                });
                item.Children = await GetMenuTreeWithActionAsync(item.Id);
            }
            return roots;
        }

        public async Task InitControllerAsync(Type type)
        {
            List<string> controllers = new List<string>();
                Assembly assembly = Assembly.LoadFrom(CHelperAppDomain.CombineWithBaseDirectory("Jt.SingleService.dll"));
                var controllerTypes = CHelperAssembly.GetDerived(assembly, type);
                controllerTypes.ForEach(x => controllers.Add(x.Name));

            await _menuCacheSvc.SetControllerAsync(controllers);
        }

        public async Task InsertMenuAsync(Menu menu)
        {
            await _repository.InsertAsync(menu);
            await _repository.SaveAsync();
        }

        public async Task<bool> IsExistsMenuAsync(Menu menu)
        {
            var existsMenu = await _repository.GetMenuByNameAsync(menu.Name);
            if (menu.Id.IsNotNullOrWhiteSpace() && existsMenu != null && existsMenu.Id == menu.Id)
            {
                return false;
            }
            return existsMenu != null;
        }

        public async Task UpdateMenuAsync(Menu menu)
        {
           await _repository.UpdateAsync(menu);
          await  _repository.SaveAsync();
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
