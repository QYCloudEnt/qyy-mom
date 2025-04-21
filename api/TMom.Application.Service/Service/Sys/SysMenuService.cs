using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TMom.Application.Dto.Sys;
using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model.Params;
using TMom.Infrastructure;
using TMom.Infrastructure.Helper;
using System.Reflection;

namespace TMom.Application.Service.Service
{
    public class SysMenuService : BaseService<SysMenu, int>, ISysMenuService
    {
        private readonly IBaseRepository<SysMenu, int> _dal;
        private readonly IMapper _mapper;
        private readonly ISysMenuRepository _sysMenuRepository;
        private readonly IUser _user;
        private readonly ISysRoleMenuService _sysRoleMenuService;
        private readonly IWebHostEnvironment Env;
        private readonly ILog log = LogManager.GetLogger(typeof(SysMenuService));

        public SysMenuService(IBaseRepository<SysMenu, int> dal, IMapper mapper, ISysMenuRepository sysMenuRepository, IUser user
            , ISysRoleMenuService sysRoleMenuService, IWebHostEnvironment env)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _mapper = mapper;
            _sysMenuRepository = sysMenuRepository;
            _user = user;
            _sysRoleMenuService = sysRoleMenuService;
            Env = env;
        }

        /// <summary>
        /// 根据用户Id获取用户权限菜单(tree)
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PermMenuDto> GetMenusByUserId(int iD)
        {
            List<SysMenu> sysMenuList = await _sysMenuRepository.GetMenusByUserId(iD);
            // 非开发环境去除 代码生成 页面
            if (!Env.IsDevelopment())
            {
                sysMenuList = sysMenuList.Where(x => x.LinkUrl != "/dev/autocode").ToList();
            }
            var normalMenuList = (from menu in sysMenuList.Where(x => x.Type != 2)
                                  select new MenuTree()
                                  {
                                      Id = menu.Id,
                                      ParentId = menu.ParentId,
                                      Name = menu.MenuName,
                                      Component = RenderComponent(menu),
                                      Path = RenderPath(menu),
                                      Meta = new MenuMeta()
                                      {
                                          ActiveMenu = menu.IsExternal || menu.IsShow
                                            ? null
                                            : sysMenuList.FirstOrDefault(t => t.Id == menu.ParentId)?.LinkUrl,
                                          Type = menu.Type,
                                          Icon = menu.Icon ?? "ant-design:bar-chart-outlined",
                                          Title = menu.MenuName,
                                          Show = menu.IsShow,
                                          KeepAlive = menu.IsKeepAlive,
                                          OrderNo = menu.OrderSort,
                                          IsExt = menu.IsExternal,
                                          ExtOpenMode = menu.IsEmbed ? 2 : 1,
                                          FrameRoute = menu.IsExternal ? menu.LinkUrl : null,
                                          HideInMenu = !menu.IsShow
                                      },
                                  }).ToList();
            var result = new MenuTree();
            RecursionHelper.LoopToAppendChildrenT(normalMenuList, result);

            var hideMenuList = (from menu in sysMenuList.Where(x => x.Type != 2 && !x.IsShow)
                                select new MenuTree()
                                {
                                    Id = menu.Id,
                                    ParentId = menu.ParentId,
                                    Name = menu.MenuName,
                                    Component = RenderComponent(menu),
                                    Path = RenderPath(menu),
                                    Meta = new MenuMeta()
                                    {
                                        ActiveMenu = menu.IsExternal || menu.IsShow
                                            ? null
                                            : sysMenuList.FirstOrDefault(t => t.Id == menu.ParentId)?.LinkUrl,
                                        Type = menu.Type,
                                        Icon = menu.Icon ?? "ant-design:bar-chart-outlined",
                                        Title = menu.MenuName,
                                        Show = menu.IsShow,
                                        KeepAlive = menu.IsKeepAlive,
                                        OrderNo = menu.OrderSort,
                                        IsExt = menu.IsExternal,
                                        ExtOpenMode = menu.IsEmbed ? 2 : 1,
                                        FrameRoute = menu.IsExternal ? menu.LinkUrl : null,
                                        HideInMenu = true
                                    },
                                }).ToList();
            var menuList = result.Children.Union(hideMenuList).ToList();

            var perms = sysMenuList.Where(x => x.Type == 2).Select(x => x.LinkUrl).Distinct().ToList();
            PermMenuDto permMenu = new PermMenuDto()
            {
                menus = menuList,
                perms = perms
            };
            return permMenu;
        }

        private string RenderComponent(SysMenu menu)
        {
            if (menu.Type == 0 || menu.IsExternal || string.IsNullOrWhiteSpace(menu.ViewPath)) return "";
            return menu.ViewPath;
        }

        private string RenderPath(SysMenu menu)
        {
            if (menu.IsExternal) return menu.ViewPath ?? "";
            return menu.LinkUrl ?? "";
        }

        /// <summary>
        /// 获取所有包含权限的方法
        /// </summary>
        /// <returns></returns>
        public List<string> GetPermList()
        {
            var perms = new List<string>();
            try
            {
                var path = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
                var referencedAssemblies = Directory.GetFiles(path, "TMom.Api.dll").Select(Assembly.LoadFrom).ToArray();
                // 所有的控制器
                var controllerList = referencedAssemblies.SelectMany(a => a.DefinedTypes)
                                                         .Select(type => type.AsType())
                                                         .Where(x => x.IsClass && x.Name.EndsWith("Controller") && x.IsPublic)
                                                         .ToList();
                // 权限在方法中
                var perm_actions = controllerList.SelectMany(x => x.GetMethods())
                                                 .Select(action => action)
                                                 .Where(a => a.GetCustomAttributes().Any(t => t is AuthorizeAttribute))
                                                 .ToList();
                // 权限在控制器中,方法中没有 [AllowAnonymous]
                controllerList.AsParallel().ForAll(item =>
                {
                    if (item.GetCustomAttribute<AuthorizeAttribute>() != null)
                    {
                        var methods = item.GetMethods()
                                          .Where(x => x.DeclaringType?.Name == item.Name && !x.GetCustomAttributes()
                                          .Any(t => t is AllowAnonymousAttribute));
                        perm_actions.AddRange(methods);
                    }
                });
                // action  ==>  /api/SysUser/GetWithPage
                perms = perm_actions.Select(x => $"/api/{x?.DeclaringType?.Name.Replace("Controller", "")}/{x?.Name}")
                                    .Distinct()
                                    .OrderBy(x => x)
                                    .ToList();
            }
            catch (Exception e)
            {
                log.Error($"【错误信息】：{e.Message}, \r\n【堆栈信息】：{e.StackTrace}");
            }
            return perms;
        }

        #region 代码生成后, 添加菜单和权限

        /// <summary>
        /// Index页面
        /// </summary>
        /// <param name="param"></param>
        [UseTran]
        public async Task addMenuAndPermForIndex(CodeFirstParams param)
        {
            List<SysMenu> menuList = new List<SysMenu>();
            List<SysRoleMenu> roleMenuList = new List<SysRoleMenu>();
            int sortNo = 0;
            var menu = await Query(x => x.ParentId == param.parentId);
            if (menu != null && menu.Any())
            {
                sortNo = menu.Max(x => x.OrderSort);
            }
            foreach (string tabName in param.tableNames)
            {
                // 1.菜单
                // SysUser  -->  user
                string key = tabName.Replace($"{param.fileName}_", "").Replace(param.fileName, "").FirstToLower();
                // /sys/user
                string url = $"/{param.fileName.FirstToLower()}/{key}";
                bool isExist = (await Query(x => x.LinkUrl == url)).Any();
                if (isExist) continue;
                sortNo++;
                SysMenu sysMenu = new SysMenu()
                {
                    MenuName = param.menuName,
                    ParentId = param.parentId,
                    Icon = param.icon,
                    Type = 1,
                    LinkUrl = url,
                    ViewPath = $"{url}/index",
                    IsKeepAlive = true,
                    IsShow = true,
                    OrderSort = sortNo
                };
                sysMenu.UpdateCommonFields(_user.Id);
                int menuId = await this.Add(sysMenu);
                // 默认给管理员角色添加菜单和权限
                roleMenuList.Add(new SysRoleMenu() { SysRoleId = 1, SysMenuId = menuId });

                // 2.权限
                await addApiPerm(roleMenuList, menuId, "查询", $"/api/{tabName}/GetWithPage");
                await addApiPerm(roleMenuList, menuId, "新增", $"/api/{tabName}/Add");
                await addApiPerm(roleMenuList, menuId, "编辑", $"/api/{tabName}/Update");
                await addApiPerm(roleMenuList, menuId, "删除", $"/api/{tabName}/Delete");
            }
            roleMenuList.ForEach(roleMenu => roleMenu.UpdateCommonFields(_user.Id));
            await _sysRoleMenuService.Add(roleMenuList);
        }

        /// <summary>
        /// 添加Api权限
        /// </summary>
        /// <param name="roleMenuList"></param>
        /// <param name="menuId"></param>
        /// <param name="permName"></param>
        /// <param name="apiUrl"></param>
        private async Task addApiPerm(List<SysRoleMenu> roleMenuList, int menuId, string permName, string apiUrl)
        {
            SysMenu sysMenu = new SysMenu()
            {
                MenuName = permName,
                ParentId = menuId,
                Type = 2,
                LinkUrl = apiUrl,
                IsKeepAlive = false,
                IsShow = false,
                OrderSort = 0
            };
            sysMenu.UpdateCommonFields(_user.Id);
            int permId = await Add(sysMenu);
            SysRoleMenu roleMenu = new SysRoleMenu()
            {
                SysRoleId = 1, // 默认管理员
                SysMenuId = permId
            };
            roleMenuList.Add(roleMenu);
        }

        /// <summary>
        /// Index、Detail页面
        /// </summary>
        /// <param name="param"></param>
        [UseTran]
        public async Task addMenuAndPermForIndexDetail(CodeFirstParams param)
        {
            await addMenuAndPermForIndex(param);

            List<SysMenu> menuList = new List<SysMenu>();
            List<SysRoleMenu> roleMenuList = new List<SysRoleMenu>();
            foreach (string tabName in param.tableNames)
            {
                // SysUser  -->  user
                string key = tabName.Replace(param.fileName, "").FirstToLower();
                // /sys/user
                string url = $"/{param.fileName.FirstToLower()}/{key}/detail";
                bool isExist = (await Query(x => x.LinkUrl == url)).Any();
                if (isExist) continue;
                var parentMenu = await QuerySingle(x => x.LinkUrl == $"/{param.fileName.FirstToLower()}/{key}");
                if (parentMenu == null || parentMenu.Id == 0) continue;
                SysMenu sysMenu = new SysMenu()
                {
                    MenuName = $"{param.menuName}-详情",
                    ParentId = parentMenu.Id,
                    Type = 1,
                    LinkUrl = $"{url}/:id",
                    ViewPath = $"{url}.vue",
                    IsKeepAlive = false,
                    IsShow = false,
                    OrderSort = 0
                };
                sysMenu.UpdateCommonFields(_user.Id);
                int menuId = await Add(sysMenu);
                // 默认给管理员角色添加菜单和权限
                roleMenuList.Add(new SysRoleMenu() { SysRoleId = 1, SysMenuId = menuId });
            }
            roleMenuList.ForEach(roleMenu => roleMenu.UpdateCommonFields(_user.Id));
            await _sysRoleMenuService.Add(roleMenuList);
        }

        #endregion 代码生成后, 添加菜单和权限
    }
}