using System.Threading.Tasks;

namespace BlissRecruitment.Domain.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
