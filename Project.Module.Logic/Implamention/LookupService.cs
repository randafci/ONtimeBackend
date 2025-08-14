using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnTime.CrossCutting.Comman;
using OnTime.CrossCutting.Data.Repository;
using OnTime.Lookups.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tanafos.Shared.Lookups.Services.Implementation
{
    public class LookupService<T, TDto> : ILookupService<T, TDto> where T : class, ILookup where TDto : class
    {
        private ICrossCuttingRepository<T> _repository;
        protected readonly IMapper _mapper;

        public LookupService(ICrossCuttingRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<T> GetLookupItemById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<T> AddLookupItem(TDto item)
        {
            var entity = _mapper.Map<T>(item);

            return await _repository.AddAsync(entity);
        }
        public async Task<T> GetLookupItemByName(string  name)
        {
            return await _repository.FindOneAsync(x=>x.Name== name);
        }
        public async Task< List<T>> GetLookupItems(bool includeDeleted = false)
        {
            var items = _repository.Find(x =>  (includeDeleted || x.IsDeleted == false));
            return await items.ToListAsync();
        }

        public async Task< List<T>> GetLookupItemsByParentId(string parentKey, int parentId, bool includeDeleted = false)
        {
            IQueryable<T> items = _repository.Find(x =>! x.IsDeleted && (includeDeleted ? true : x.IsDeleted == false));

          //  Type type = parentKey == nameof(City.RegionId) ? typeof(int?) : typeof(int);

           // items = items.Filter<T>(parentKey, type, parentId, true);
            return await items.ToListAsync();
        }
    }
}   