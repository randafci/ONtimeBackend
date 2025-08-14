using OnTime.CrossCutting.Comman;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnTime.Lookups.Services.Contracts
{
    public interface ILookupService<T, TDto> where T : class, ILookup where TDto : class
    {
        Task<List<T>> GetLookupItems(bool includeDeleted = false);
        Task<T> GetLookupItemById(int id);
        Task< List<T>> GetLookupItemsByParentId(string parentKey, int parentId, bool includeDeleted = false);
        Task<T> GetLookupItemByName(string name);
        Task<T> AddLookupItem(TDto item);
    }
}