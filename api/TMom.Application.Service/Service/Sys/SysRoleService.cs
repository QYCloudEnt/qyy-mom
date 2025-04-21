using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Application.Service.Service
{
    public class SysRoleService : BaseService<SysRole, int>, ISysRoleService
    {
        private readonly IBaseRepository<SysRole, int> _dal;

        public SysRoleService(IBaseRepository<SysRole, int> dal)
        {
            this._dal = dal;
            base.BaseRepo = dal;
        }
    }
}