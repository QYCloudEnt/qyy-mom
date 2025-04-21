using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Application.Service.Service
{
    public class SysOrgService : BaseService<SysOrg, int>, ISysOrgService
    {
        private readonly IBaseRepository<SysOrg, int> _dal;
        private readonly ISysOrgRepository _sysOrgRepository;

        public SysOrgService(IBaseRepository<SysOrg, int> dal, ISysOrgRepository SysOrgRepository)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _sysOrgRepository = SysOrgRepository;
        }
    }
}