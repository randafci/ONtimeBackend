using OnTime.Data.Entities;
using OnTime.Data.IGenericRepository_IUOW;
using OnTime.EntityFramework.DataBaseContext;
using OnTime.Comman.Idenitity;
using ProjectPulse.Data.Entities;

namespace OnTime.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
     
        public IGeneralRepository<ApplicationUser> Users { get; private set; }
        public IGeneralRepository<Customer> Customers { get; }
        public IGeneralRepository<Organization> Organizations { get; }
        public IGeneralRepository<Job> Jobs { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
          
            Users= new GeneralRepository<ApplicationUser>(_context);
            Customers= new GeneralRepository<Customer>(_context);
        }
        public async Task<bool> SaveAsync()
        {
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
