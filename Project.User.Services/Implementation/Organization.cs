using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnTime.Data.Entities;
using OnTime.Data.IGenericRepository_IUOW;
using OnTime.ResponseHandler.Models;
using OnTime.Services.DataTransferObject.Customer;
using ProjectPulse.Data.Entities;
using ProjectPulse.User.Services.DataTransferObject.Organization;
using ProjectPulse.User.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPulse.User.Services.Implementation
{
    public class OrganizationService : IOrganization
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrganizationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<APIOperationResponse<OrganizationCreateModel>> CreateOrganizationAsync(OrganizationCreateModel model)
        {
            try
            {
                var organization = _mapper.Map<Organization>(model);

                await _unitOfWork.Organizations.AddAsync(organization);
                await _unitOfWork.SaveAsync();

                var result = _mapper.Map<OrganizationCreateModel>(organization);
                return APIOperationResponse<OrganizationCreateModel>.Created("Organization created successfully");
            }
            catch (Exception ex)
            {
                return APIOperationResponse<OrganizationCreateModel>.ServerError(
                    "An error occurred while creating the organization",
                    new List<string> { ex.Message });
            }
        }

        public async Task<APIOperationResponse<bool>> DeleteOrganizationAsync(int id)
        {
            try
            {
                var organization = await _unitOfWork.Organizations.GetByIdAsync(id);

                if (organization == null)
                {
                    return APIOperationResponse<bool>.NotFound("Organization not found");
                }

                await _unitOfWork.Organizations.DeleteAsync(organization);
                await _unitOfWork.SaveAsync();

                return APIOperationResponse<bool>.Success(true, "Organization deleted successfully");
            }
            catch (Exception ex)
            {
                return APIOperationResponse<bool>.ServerError(
                    "An error occurred while deleting the organization",
                    new List<string> { ex.Message });
            }
        }

        public async Task<APIOperationResponse<List<CustomerGetAllModel>>> GetAllOrganizationAsync()
        {
            try
            {
                var organizations = await _unitOfWork.Organizations.GetAllAsync();

                if (!organizations.Any())
                {
                    return APIOperationResponse<List<CustomerGetAllModel>>.NoContent();
                }

                var result = _mapper.Map<List<CustomerGetAllModel>>(organizations);
                return APIOperationResponse<List<CustomerGetAllModel>>.Success(
                    result, "Organizations retrieved successfully");
            }
            catch (Exception ex)
            {
                return APIOperationResponse<List<CustomerGetAllModel>>.ServerError(
                    "An error occurred while retrieving organizations",
                    new List<string> { ex.Message });
            }
        }

        public async Task<APIOperationResponse<OrganizationCreateModel>> UpdateOrganizationAsync(OrganizationCreateModel model)
        {
            try
            {
                if (model.Id == null || model.Id <= 0)
                {
                    return APIOperationResponse<OrganizationCreateModel>.BadRequest("Invalid organization ID");
                }

                var existingOrg = await _unitOfWork.Organizations.GetByIdAsync(model.Id);

                if (existingOrg == null)
                {
                    return APIOperationResponse<OrganizationCreateModel>.NotFound("Organization not found");
                }

                _mapper.Map(model, existingOrg);
                await _unitOfWork.Organizations.UpdateAsync(existingOrg);
                await _unitOfWork.SaveAsync();

                var result = _mapper.Map<OrganizationCreateModel>(existingOrg);
                return APIOperationResponse<OrganizationCreateModel>.Success(
                    result, "Organization updated successfully");
            }
            catch (Exception ex)
            {
                return APIOperationResponse<OrganizationCreateModel>.ServerError(
                    "An error occurred while updating the organization",
                    new List<string> { ex.Message });
            }
        }
    }
}