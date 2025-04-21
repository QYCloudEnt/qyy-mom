using SqlSugar;
using System.Reflection;

namespace TMom.Infrastructure.Repository
{
    public interface IUnitOfWork
    {
        SqlSugarScope GetDbClient();

        int TranCount { get; }

        void BeginTran();

        void BeginTran(MethodInfo method);

        void CommitTran();

        void CommitTran(MethodInfo method);

        void RollbackTran();

        void RollbackTran(MethodInfo method);
    }
}