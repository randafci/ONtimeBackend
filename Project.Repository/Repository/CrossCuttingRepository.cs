using OnTime.EntityFramework.DataBaseContext;
using OnTime.Repository.Repository;

namespace OnTime.CrossCutting.Data.Repository
{
    public class CrossCuttingRepository<T> : GeneralRepository<T>, ICrossCuttingRepository<T> where T : class
    {
        public CrossCuttingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
