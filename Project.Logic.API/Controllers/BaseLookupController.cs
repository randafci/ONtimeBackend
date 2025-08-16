using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System.Threading.Tasks;
using System;
using OnTime.CrossCutting.Comman;
using OnTime.Lookups.Services.Contracts;
using OnTime.ResponseHandler.Models;

namespace OnTime.Lookups.Domain.API.Controllers
{

    [Route("api/Lookup/[controller]")]
    [Produces("application/json")]


    public abstract class LookupController<T, TDto> : ApiControllerBase where T : class, ILookup where TDto : class 
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
        public virtual async Task<IActionResult> Get(string controller)
        {
            return ProcessResponse( await _lookupService.GetLookupItems());
        }

        [HttpPost]
        public virtual async Task<IActionResult> post( [FromBody] TDto item)
        {
            return ProcessResponse(await _lookupService.AddLookupItem(item));
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Put(int id, [FromBody] TDto item)
        {
            
                var updated = await _lookupService.UpdateLookupItem(id, item);
                return ProcessResponse(updated);
           
        }

        /// <summary>
        /// Search lookup items by code, name, or nameSE
        /// </summary>
        [HttpGet("search")]
        public virtual async Task<ActionResult> Search([FromQuery] string searchText, [FromQuery] bool includeDeleted = false)
        {
            var results = await _lookupService.SearchLookupItems(searchText, includeDeleted);
            return ProcessResponse(results);
        }
        /// <summary>
        /// Get Lookup Item by Id.
        /// </summary>
        /// <param name="lookupName"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> LookupItem(string controller, int Id)
        {
            return ProcessResponse(await _lookupService.GetLookupItemById(Id));
        }

        /// <summary>
        /// Get Lookup Items using IsDeleted Flag.
        /// </summary>
        /// <param name="lookupName"></param>
        /// <param name="IncludeDeleted"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("LookupItemsWithDeleted/{IncludeDeleted?}")]
        public async Task<IActionResult> LookupItems(string controller, bool? IncludeDeleted = false)
        {
            return ProcessResponse(await _lookupService.GetLookupItems(IncludeDeleted.Value));
        }

        [HttpGet]
        [Route("LookupItemsByParentId/{ParentId}/{IncludeDeleted?}")]
        public async Task<IActionResult> LookupItemsByParentId(string controller, int ParentId, bool? IncludeDeleted = false)
        {
            return ProcessResponse( await _lookupService.GetLookupItemsByParentId(_parentKey, ParentId, IncludeDeleted.Value));
        }
    }
}