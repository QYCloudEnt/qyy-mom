using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// SkillRepository
    /// </summary>
    public class SkillRepository : BaseRepository<Skill, int>, ISkillRepository
    {
        public SkillRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}