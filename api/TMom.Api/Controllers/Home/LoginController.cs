using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMom.Application;
using TMom.Application.Dto;
using TMom.Application.Dto.Sys;
using TMom.Application.Service;
using TMom.Application.Service.IService;
using TMom.Domain.Model;
using TMom.Domain.Model.Entity;
using TMom.Infrastructure.Common;
using TMom.Infrastructure.Helper;
using TMom.Infrastructure.Repository;
using SqlSugar;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Api.Controllers.Home
{
    /// <summary>
    /// 登录
    /// </summary>
    [Produces("application/json")]
    [Route("api/Login")]
    [AllowAnonymous]
    public class LoginController : BaseApiController<SysUser, int>
    {
        private readonly ISysUserService _sysUserService;
        private readonly ISysUserRoleService _sysUserRoleServic;
        private readonly ISysRoleService _sysRoleService;
        private readonly PermissionRequirement _requirement;
        private readonly ISysRoleMenuService _sysRoleMenuService;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="sysUserService"></param>
        /// <param name="sysUserRoleServic"></param>
        /// <param name="sysRoleService"></param>
        /// <param name="requirement"></param>
        /// <param name="sysRoleMenuService"></param>
        /// <param name="unitOfWork"></param>
        public LoginController(ISysUserService sysUserService, ISysUserRoleService sysUserRoleServic
            , ISysRoleService sysRoleService
            , PermissionRequirement requirement
            , ISysRoleMenuService sysRoleMenuService
            , IUnitOfWork unitOfWork
            )
        {
            this._sysUserService = sysUserService;
            this._sysUserRoleServic = sysUserRoleServic;
            this._sysRoleService = sysRoleService;
            _requirement = requirement;
            _sysRoleMenuService = sysRoleMenuService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 获取JWT
        /// </summary>
        /// <param name="loginParams">登录参数</param>
        /// <returns></returns>
        [HttpPost]
        [Route("JWTToken")]
        public async Task<MessageModel<TokenInfoViewModel>> GetJwtToken([FromBody] loginParams loginParams)
        {
            string jwtStr = string.Empty;
            string username = loginParams.username;
            string password = loginParams.password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return Failed<TokenInfoViewModel>("用户名或密码不能为空!");

            password = MD5Helper.MD5Encrypt32(password);

            var whereExpression = Expressionable.Create<SysUser>()
                                                .And(x => x.LoginAccount == username)
                                                .And(x => x.Password == password)
                                                .And(x => x.IsEnabled && !x.IsDeleted)
                                                .ToExpression();

            var user = await _sysUserService.QuerySingle(whereExpression);
            if (user != null)
            {
                (var userRoles, string userId) = await _sysUserService.GetUserRoleNameStr(username);
                var now = DateTime.Now;
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(JwtRegisteredClaimNames.Jti, userId),
                    new Claim(ClaimTypes.Expiration, now.AddSeconds(_requirement.Expiration.TotalSeconds).ToString()) };
                claims.AddRange(userRoles.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));

                var data = await _sysRoleMenuService.RoleMenuMaps();
                var list = (from item in data
                            where item.IsDeleted == false && item.SysMenu?.Type == 2
                            orderby item.Id
                            select new PermissionItem
                            {
                                Url = item.SysMenu?.LinkUrl,
                                Role = item.SysRole?.RoleName,
                            })?.ToList();

                _requirement.Permissions = list;

                var token = JwtToken.BuildJwtToken(claims.ToArray(), _requirement, now);
                return Success(token, "token获取成功");
            }
            else
            {
                return Failed<TokenInfoViewModel>("账号或密码错误, 请重试!");
            }
        }

        /// <summary>
        /// 请求刷新Token（以旧换新）/ 解锁屏幕
        /// </summary>
        /// <param name="token"></param>
        /// <param name="pwd">密码, 解锁屏幕需要传递该参数</param>
        /// <returns></returns>
        [HttpGet]
        [Route("RefreshToken")]
        public async Task<MessageModel<TokenInfoViewModel>> RefreshToken(string token = "", string pwd = "")
        {
            string jwtStr = string.Empty;

            if (string.IsNullOrEmpty(token))
                return Failed<TokenInfoViewModel>("token无效，请重新登录！");
            var tokenModel = JwtHelper.SerializeJwt(token);
            if (tokenModel != null && JwtHelper.customSafeVerify(token) && tokenModel.Uid > 0)
            {
                var user = await _sysUserService.QueryById(tokenModel.Uid);
                if (!string.IsNullOrWhiteSpace(pwd) && MD5Helper.MD5Encrypt32(pwd) != user.Password)
                {
                    return Failed<TokenInfoViewModel>("密码输入有误, 请重新输入!");
                }
                if (user != null)
                {
                    (var userRoles, string userId) = await _sysUserService.GetUserRoleNameStr(user.LoginAccount);
                    var now = DateTime.Now;
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.LoginAccount),
                    new Claim(JwtRegisteredClaimNames.Jti, tokenModel.Uid.ObjToString()),
                    new Claim(ClaimTypes.Expiration, now.AddSeconds(_requirement.Expiration.TotalSeconds).ToString()) };
                    claims.AddRange(userRoles.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));

                    var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
                    identity.AddClaims(claims);

                    var data = await _sysRoleMenuService.RoleMenuMaps();
                    var list = (from item in data
                                where item.IsDeleted == false && item.SysMenu?.Type == 2
                                orderby item.Id
                                select new PermissionItem
                                {
                                    Url = item.SysMenu?.LinkUrl,
                                    Role = item.SysRole?.RoleName,
                                }).ToList();

                    _requirement.Permissions = list;
                    var refreshToken = JwtToken.BuildJwtToken(claims.ToArray(), _requirement, now);
                    return Success(refreshToken, "获取成功");
                }
            }
            return Failed<TokenInfoViewModel>("账号或密码错误, 请重试!");
        }
    }
}