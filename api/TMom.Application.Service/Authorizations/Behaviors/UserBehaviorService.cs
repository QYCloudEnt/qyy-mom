using Microsoft.Extensions.Logging;
using TMom.Domain.Model;
using TMom.Infrastructure;

namespace TMom.Application.Service
{
    public class UserBehaviorService : IUserBehaviorService
    {
        private readonly IUser _user;

        //private readonly ISysUserInfoService _sysUserInfoServices;
        private readonly ILogger<UserBehaviorService> _logger;

        private readonly string _uid;
        private readonly string _token;

        public UserBehaviorService(IUser user
            //, ISysUserInfoService sysUserInfoServices
            , ILogger<UserBehaviorService> logger)
        {
            _user = user;
            //_sysUserInfoServices = sysUserInfoServices;
            _logger = logger;
            _uid = _user.Id.ObjToString();
            _token = _user.GetToken();
        }

        public Task<bool> CheckTokenIsNormal()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CheckUserIsNormal()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CreateOrUpdateUserAccessByUid()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveAllUserAccessByUid()
        {
            throw new System.NotImplementedException();
        }
    }
}