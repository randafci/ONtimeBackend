using OnTime.CrossCutting.Comman;
using OnTime.ResponseHandler.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnTime.Lookups.Services.Contracts
{
    public interface ILookupService<T, TDto> where T : class, ILookup where TDto : class
    {
        Task<APIOperationResponse<List<T>>> GetLookupItems(bool includeDeleted = false);
        Task<APIOperationResponse<T>> GetLookupItemById(int id);
        Task< APIOperationResponse< List<T>>> GetLookupItemsByParentId(string parentKey, int parentId, bool includeDeleted = false);
        Task<APIOperationResponse<T>> GetLookupItemByName(string name);
        Task<APIOperationResponse<T>> AddLookupItem(TDto item);
        Task<APIOperationResponse<T>> UpdateLookupItem(int id, TDto item);
        Task<APIOperationResponse<List<T>>> SearchLookupItems(string searchText, bool includeDeleted = false);
    }
}