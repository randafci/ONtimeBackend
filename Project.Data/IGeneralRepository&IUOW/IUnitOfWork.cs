using OnTime.Data.Entities;
using OnTime.Comman.Idenitity;
using ProjectPulse.Data.Entities;

namespace OnTime.Data.IGenericRepository_IUOW
{
    public interface IUnitOfWork : IDisposable
    {
     
        public IGeneralRepository<ApplicationUser> Users { get; }
        public IGeneralRepository<Customer> Customers { get; }
        public IGeneralRepository<Organization> Organizations { get; }
        public IGeneralRepository<Job> Jobs { get; }


        Task<bool> SaveAsync();
    }
}
