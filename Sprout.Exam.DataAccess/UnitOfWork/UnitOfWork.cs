using Sprout.Exam.DataAccess.Entities;
using Sprout.Exam.DataAccess.Interface;
using Sprout.Exam.DataAccess.Repository;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SproutExamDbContext _context;
        private IGenericRepository<Employee> _employee;

        public UnitOfWork()
        {
            _context = new SproutExamDbContext();
        }

       
        public IGenericRepository<Employee> Employee
        {
            get { return _employee ??= new GenericRepository<Employee>(_context); }
        }


        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
