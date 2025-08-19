﻿using Microsoft.AspNetCore.Http;
using OnTime.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.User.Services.Implementation
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string? UserName => _httpContextAccessor.HttpContext?.User?.Identity?.Name;
        public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        public long? EmployeeId => Convert.ToInt64(_httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(item => item.Type == "employeeId")?.Value);
        public bool IsAdminRole => Convert.ToBoolean(_httpContextAccessor
            .HttpContext?
            .User?
            .Claims
            .FirstOrDefault(item => item.Type == "isAdminRole")?.Value);
        public bool IsHrRole => Convert.ToBoolean(_httpContextAccessor
            .HttpContext?
            .User?
            .Claims
            .FirstOrDefault(item => item.Type == "isHrRole")?.Value);
        public bool IsReportingManager => Convert.ToBoolean(_httpContextAccessor
            .HttpContext?
            .User?
            .Claims
            .FirstOrDefault(item => item.Type == "isReportingManager")?.Value);
        public bool IsHrEmployee => Convert.ToBoolean(_httpContextAccessor
            .HttpContext?
            .User?
            .Claims
            .FirstOrDefault(item => item.Type == "isHrEmployee")?.Value);
        public bool IsTrainingEmployee => Convert.ToBoolean(_httpContextAccessor
            .HttpContext?
            .User?
            .Claims
            .FirstOrDefault(item => item.Type == "isTrainingEmployee")?.Value);
        public bool IsResponsibleEmployee => Convert.ToBoolean(_httpContextAccessor
            .HttpContext?
            .User?
            .Claims
            .FirstOrDefault(item => item.Type == "isResponsibleEmployee")?.Value);
        public bool IncludeEmployeeViewInManagerDashboard => Convert.ToBoolean(_httpContextAccessor
            .HttpContext?
            .User?
            .Claims
            .FirstOrDefault(item => item.Value == "IncludeEmployeeViewInManagerDashboard")?.Value != null);
   
        public List<string>? Roles => _httpContextAccessor
            .HttpContext?
            .User?
            .Claims
            .Where(item => item.Type == ClaimTypes.Role)
            .Select(item => item.Value)
            .ToList();
        public List<long> EntityIds => _httpContextAccessor
            .HttpContext?
            .User?
            .Claims
            .FirstOrDefault(item => item.Type == "Permissions-EnityList")?
            .Value?
            .Split(',')
            .Select(long.Parse)
            .OrderBy(item => item)
            .ToList() ?? new List<long>();
        public List<long> ExtraEmployeesView => _httpContextAccessor
            .HttpContext?
            .User?
            .Claims
            .FirstOrDefault(item => item.Type == "extraEmployeesView")?
            .Value?
            .Split(',')
            .Select(long.Parse)
            .OrderBy(item => item)
            .ToList() ?? new List<long>();
        public List<long> ExtraRoleEmployeesView => _httpContextAccessor
            .HttpContext?
            .User?
            .Claims.FirstOrDefault(item => item.Type == "Permissions-ExtraEmployeesView")?
            .Value?
            .Split(',')
            .Select(long.Parse)
            .OrderBy(item => item)
            .ToList() ?? new List<long>();
        public List<long> AllowedLeaveClausesIds => _httpContextAccessor
            .HttpContext?
            .User?
            .Claims.FirstOrDefault(item => item.Type == "Permissions-AllowedLeaveClauses")?
            .Value?
            .Split(',')
            .Select(long.Parse)
            .ToList() ?? new List<long>();
        public List<long> AllowedPermissionClausesIds => _httpContextAccessor
            .HttpContext?
            .User?
            .Claims.FirstOrDefault(item => item.Type == "Permissions-AllowedPermissionClauses")?
            .Value?
            .Split(',')
            .Select(long.Parse)
            .ToList() ?? new List<long>();

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsUserHasClaim(string claimName)
        {
            return _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(item => item.Value == claimName) != null;
        }
        public long? OrganoztionId => Convert.ToInt64(_httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(item => item.Type == "OrganoztionId")?.Value);

    }
}
