﻿namespace OnTime.Infrastructure.Utilities;

using System.ComponentModel;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnTime.Application.Common.Models;
using OnTime.CrossCutting.Comman.Models.Identity;
using OnTime.Domain.Entities;
using OnTime.EntityFramework.DataBaseContext;
using OnTime.Infrastructure.Enums;

public class CrudPermissionsGenerator
{

    private readonly ApplicationDbContext _context;

    public const string Reports = "Reports";
    public const string Requests = "Requests";
    public const string Analytics = "Analytics";
    public const string Approvals = "Approvals";
    public const string EmployeeData = "EmployeeData";
    public const string TimeScheduling = "TimeScheduling";
    public const string UserManagement = "UserManagement";
    public const string SettingsSupport = "SettingsSupport";
    public const string DeviceManagement = "DeviceManagement";
    public const string AttendanceSettings = "AttendanceSettings";
    public const string OrganizationSettings = "OrganizationSettings";

    public CrudPermissionsGenerator(
       
        ApplicationDbContext context)
    {
        _context = context;
      
    }

    public async Task<List<CrudPermissions>> GenerateAllPermissions()
    {
        var reports = new List<ReportItem>();
        var permissions = new List<CrudPermissions>();
        var employeeSettings = new EmployeeSettings();
        var fields = typeof(MainEntities).GetFields();
        //if (await _context.TableExistsAsync("Reports"))
        //{
        //    reports = await _context.Reports
        //        .AsNoTracking()
        //        .Where(item => item.IsPublic)
        //        .Select(item => new ReportItem()
        //        {
        //            Name = item.Name,
        //            DisplayName = item.DisplayName,
        //        })
        //        .ToListAsync();
        //}
        //if (await _context.TableExistsAsync("Settings"))
        //{
        //    employeeSettings = await _settings.GetEmployeeSettings();
        //}
        foreach (var field in fields)
        {
            var isEnabled = true;
            switch (field.Name.ToUpper())
            {
                case "JOBS":
                    isEnabled = employeeSettings.IsEnabledJob;
                    break;
                case "TEAMS":
                    isEnabled = employeeSettings.IsEnabledTeam;
                    break;
                case "GRADES":
                    isEnabled = employeeSettings.IsEnabledGrade;
                    break;
                case "FAMILIES":
                    isEnabled = employeeSettings.IsEnabledFamily;
                    break;
                case "PROJECTS":
                    isEnabled = employeeSettings.IsEnabledProject;
                    break;
                case "SECTIONS":
                    isEnabled = employeeSettings.IsEnabledSection;
                    break;
                case "COSTCENTERS":
                    isEnabled = employeeSettings.IsEnabledCostCenter;
                    break;
            }
            if (isEnabled)
            {
                permissions.Add(new CrudPermissions()
                {
                    EntityName = field.Name,
                    Category = field.GetCustomAttribute<CategoryAttribute>().Category,
                    PermissionsList = GeneratePermissionsList(field.Name, field.GetValue(null) as CrudOperation[]).Select(item => new CheckBox()
                    {
                        DisplayValue = item
                    }).ToList()
                });
            }
        }
        foreach (var report in reports)
        {
            permissions.Add(new CrudPermissions()
            {
                Category = "Reports",
                IsForReportDesinger = true,
                EntityName = report.DisplayName,
                PermissionsList = GeneratePermissionsList(report.Name, new CrudOperation[]
                {
                    CrudOperation.Page,
                    CrudOperation.View
                }).Select(item => new CheckBox()
                {
                    DisplayValue = item
                }).ToList()
            });
        }
        return permissions;
    }

    private static List<string?> GeneratePermissionsList(string entityName, CrudOperation[] operations)
    {
        return new List<string?>
        {
            operations.Contains(CrudOperation.Page) ? $"Permissions.{entityName}.Page" : null,
            operations.Contains(CrudOperation.View) ? $"Permissions.{entityName}.View" : null,
            operations.Contains(CrudOperation.Create) ? $"Permissions.{entityName}.Create" : null,
            operations.Contains(CrudOperation.Edit) ? $"Permissions.{entityName}.Edit" : null,
            operations.Contains(CrudOperation.Delete) ? $"Permissions.{entityName}.Delete" : null,
        };
    }
}
