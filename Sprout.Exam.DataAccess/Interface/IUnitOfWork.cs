using Sprout.Exam.DataAccess.Entities;
using System;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Employee> Employee { get; }

        Task<int> SaveChangesAsync();
    }
}
