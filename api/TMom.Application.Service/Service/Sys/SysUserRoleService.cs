using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Application.Service.Service
{
    public class SysUserRoleService : BaseService<SysUserRole, int>, ISysUserRoleService
    {
        private readonly IBaseRepository<SysUserRole, int> _dal;

        public SysUserRoleService(IBaseRepository<SysUserRole, int> dal)
        {
            this._dal = dal;
            base.BaseRepo = dal;
        }
    }
}