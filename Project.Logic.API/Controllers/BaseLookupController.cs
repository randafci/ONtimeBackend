using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System.Threading.Tasks;
using System;
using OnTime.CrossCutting.Comman;
using OnTime.Lookups.Services.Contracts;

namespace OnTime.Lookups.Domain.API.Controllers
{

    [Route("api/Lookup/[controller]")]
    [Produces("application/json")]


    public abstract class LookupController<T, TDto> : Controller where T : class, ILookup where TDto : class
    {

        protected readonly ILookupService<T, TDto> _lookupService;
        private readonly string _parentKey;
        public LookupController(ILookupService<T, TDto> lookupService, string parentKey)
        {
            _lookupService = lookupService;
            _parentKey = parentKey;
        }

        public LookupController(ILookupService<T, TDto> lookupService)
        {
            _lookupService = lookupService;
        }

        /// <summary>
        /// Get all Lookup Items.
        /// </summary>
        /// <param name="lookupName"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task< List<T>> Get(string controller)
        {
            return await _lookupService.GetLookupItems();
        }

        [HttpPost]
        public virtual async Task<T> post( [FromBody] TDto item)
        {
            return await _lookupService.AddLookupItem(item);
        }


        /// <summary>
        /// Get Lookup Item by Id.
        /// </summary>
        /// <param name="lookupName"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Id}")]
        public async Task<T> LookupItem(string controller, int Id)
        {
            return  await _lookupService.GetLookupItemById(Id);
        }

        /// <summary>
        /// Get Lookup Items using IsDeleted Flag.
        /// </summary>
        /// <param name="lookupName"></param>
        /// <param name="IncludeDeleted"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("LookupItemsWithDeleted/{IncludeDeleted?}")]
        public async Task< List<T>> LookupItems(string controller, bool? IncludeDeleted = false)
        {
            return await _lookupService.GetLookupItems(IncludeDeleted.Value);
        }

        [HttpGet]
        [Route("LookupItemsByParentId/{ParentId}/{IncludeDeleted?}")]
        public async Task< List<T>> LookupItemsByParentId(string controller, int ParentId, bool? IncludeDeleted = false)
        {
            return await _lookupService.GetLookupItemsByParentId(_parentKey, ParentId, IncludeDeleted.Value);
        }
    }
}