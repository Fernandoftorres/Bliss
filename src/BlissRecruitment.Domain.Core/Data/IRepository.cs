using BlissRecruitment.Domain.Core.Domain;
using System;

namespace BlissRecruitment.Domain.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}