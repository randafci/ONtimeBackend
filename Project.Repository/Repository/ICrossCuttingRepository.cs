
using OnTime.Data.IGenericRepository_IUOW;

namespace OnTime.CrossCutting.Data.Repository
{
    public interface ICrossCuttingRepository<T> : IGeneralRepository<T> where T : class
    {
    }
}
