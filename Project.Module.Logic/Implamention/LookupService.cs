using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnTime.CrossCutting.Comman;
using OnTime.CrossCutting.Data.Repository;
using OnTime.Lookups.Services.Contracts;
using OnTime.ResponseHandler.Consts;
using OnTime.ResponseHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTime.Lookups.Services.Implementation
{
   
        public class LookupService<T, TDto> : ILookupService<T, TDto>
            where T : class, ILookup
            where TDto : class
        {
            private readonly ICrossCuttingRepository<T> _repository;
            protected readonly IMapper _mapper;

            public LookupService(ICrossCuttingRepository<T> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<APIOperationResponse<T>> GetLookupItemById(int id)
            {
                try
                {
                    var result = await _repository.GetByIdAsync(id);
                    if (result == null)
                        return APIOperationResponse<T>.Fail(ResponseType.NotFound, CommonErrorCodes.NOT_FOUND, $"Lookup item with id {id} not found.");

                    return APIOperationResponse<T>.Success(result);
                }
                catch (Exception ex)
                {
                    return APIOperationResponse<T>.Fail(ResponseType.InternalServerError, CommonErrorCodes.OPERATION_FAILED, $"Error retrieving lookup by Id: {ex.Message}");
                }
            }

            public async Task<APIOperationResponse<T>> AddLookupItem(TDto item)
            {
                try
                {
                    var entity = _mapper.Map<T>(item);
                    var result = await _repository.AddAsync(entity);
                    return APIOperationResponse<T>.Success(result);
                }
                catch (Exception ex)
                {
                    return APIOperationResponse<T>.Fail(ResponseType.InternalServerError, CommonErrorCodes.OPERATION_FAILED, $"Error adding lookup item: {ex.Message}");
                }
            }

            public async Task<APIOperationResponse<T>> GetLookupItemByName(string name)
            {
                try
                {
                    var result = await _repository.FindOneAsync(x => x.Name == name);
                    if (result == null)
                        return APIOperationResponse<T> .Fail(ResponseType.NotFound, CommonErrorCodes.NOT_FOUND, $"Lookup item with name '{name}' not found.");

                    return APIOperationResponse<T>.Success(result);
                }
                catch (Exception ex)
                {
                    return APIOperationResponse<T>.Fail(ResponseType.InternalServerError, CommonErrorCodes.OPERATION_FAILED, $"Error retrieving lookup by name: {ex.Message}");
                }
            }

            public async Task<APIOperationResponse<List<T>>> GetLookupItems(bool includeDeleted = false)
            {
                try
                {
                    var items = _repository.Find(x => includeDeleted || !x.IsDeleted);
                    var result = await items.ToListAsync();
                    return APIOperationResponse<List<T>>.Success(result);
                }
                catch (Exception ex)
                {
                    return APIOperationResponse<List<T>>.Fail(ResponseType.InternalServerError, CommonErrorCodes.OPERATION_FAILED, $"Error retrieving lookup items: {ex.Message}");
                }
            }

            public async Task<APIOperationResponse<List<T>>> GetLookupItemsByParentId(string parentKey, int parentId, bool includeDeleted = false)
            {
                try
                {
                    IQueryable<T> items = _repository.Find(x => includeDeleted || !x.IsDeleted);

                    // TODO: Implement dynamic filter based on parentKey if needed
                    var result = await items.ToListAsync();
                    return APIOperationResponse<List<T>>.Success(result);
                }
                catch (Exception ex)
                {
                    return APIOperationResponse<List<T>>.Fail(ResponseType.InternalServerError, CommonErrorCodes.OPERATION_FAILED, $"Error retrieving lookup items by parent: {ex.Message}");
                }
            }

            public async Task<APIOperationResponse<T>> UpdateLookupItem(int id, TDto item)
            {
                try
                {
                    var existingEntity = await _repository.GetByIdAsync(id);
                    if (existingEntity == null)
                        return APIOperationResponse<T>.Fail(ResponseType.NotFound, CommonErrorCodes.NOT_FOUND, $"Lookup item with id {id} not found.");

                    _mapper.Map(item, existingEntity);
                    await _repository.UpdateAsync(existingEntity);

                    return APIOperationResponse<T>.Success(existingEntity);
                }
                catch (Exception ex)
                {
                    return APIOperationResponse<T>.Fail(ResponseType.InternalServerError, CommonErrorCodes.OPERATION_FAILED, $"Error updating lookup item: {ex.Message}");
                }
            }

            public async Task<APIOperationResponse<List<T>>> SearchLookupItems(string searchText, bool includeDeleted = false)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(searchText))
                    {
                        return await GetLookupItems(includeDeleted);
                    }

                    var items = _repository.Find(x =>
                        (includeDeleted || !x.IsDeleted) &&
                        (x.Name.Contains(searchText) || x.NameSE.Contains(searchText))
                    );

                    var result = await items.ToListAsync();
                    return APIOperationResponse<List<T>>.Success(result);
                }
                catch (Exception ex)
                {
                    return APIOperationResponse<List<T>>.Fail(ResponseType.InternalServerError,CommonErrorCodes.OPERATION_FAILED,$"Error searching lookup items: {ex.Message}");
                }
            }
        }
    }


