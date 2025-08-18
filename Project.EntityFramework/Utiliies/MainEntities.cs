﻿namespace OnTime.Infrastructure.Enums;

using System.ComponentModel;
using OnTime.Infrastructure.Utilities;

public enum CrudOperation
{
    Page,
    View,
    Create,
    Edit,
    Delete,
}

public static class MainEntities
{
    [Category(CrudPermissionsGenerator.Analytics)]
    public static readonly CrudOperation[] EmployeeAnalytics = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Analytics)]
    public static readonly CrudOperation[] ManagerAnalytics = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Analytics)]
    public static readonly CrudOperation[] CustomManagerEmployeeViewAnalytics = new[]
{
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Analytics)]
    public static readonly CrudOperation[] HrAnalytics = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Analytics)]
    public static readonly CrudOperation[] TrainingAnalytics = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Analytics)]
    public static readonly CrudOperation[] JudicialInspectionAnalytics = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Analytics)]
    public static readonly CrudOperation[] AttorneyGeneralAnalytics = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Analytics)]
    public static readonly CrudOperation[] Calendar = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.OrganizationSettings)]
    public static readonly CrudOperation[] Companies = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.OrganizationSettings)]
    public static readonly CrudOperation[] Departments = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.OrganizationSettings)]
    public static readonly CrudOperation[] Sections = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.OrganizationSettings)]
    public static readonly CrudOperation[] Designations = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.OrganizationSettings)]
    public static readonly CrudOperation[] Projects = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.OrganizationSettings)]
    public static readonly CrudOperation[] Grades = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.OrganizationSettings)]
    public static readonly CrudOperation[] Jobs = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.OrganizationSettings)]
    public static readonly CrudOperation[] Families = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.OrganizationSettings)]
    public static readonly CrudOperation[] Teams = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.OrganizationSettings)]
    public static readonly CrudOperation[] CostCenters = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.OrganizationSettings)]
    public static readonly CrudOperation[] Events = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.DeviceManagement)]
    public static readonly CrudOperation[] Locations = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.DeviceManagement)]
    public static readonly CrudOperation[] Devices = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.AttendanceSettings)]
    public static readonly CrudOperation[] LeaveClauses = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.AttendanceSettings)]
    public static readonly CrudOperation[] PermissionClauses = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.AttendanceSettings)]
    public static readonly CrudOperation[] Holidays = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.AttendanceSettings)]
    public static readonly CrudOperation[] RamadanPeriod = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,

    };

    [Category(CrudPermissionsGenerator.AttendanceSettings)]
    public static readonly CrudOperation[] TimeTables = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.AttendanceSettings)]
    public static readonly CrudOperation[] Shifts = new[]
{
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.AttendanceSettings)]
    public static readonly CrudOperation[] ExceptionalShifts = new[]
{
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.AttendanceSettings)]
    public static readonly CrudOperation[] TrainingCourses = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.AttendanceSettings)]
    public static readonly CrudOperation[] GeneralPolicies = new[]
{
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.AttendanceSettings)]
    public static readonly CrudOperation[] OvertimePolicies = new[]
{
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.AttendanceSettings)]
    public static readonly CrudOperation[] LeavePolicies = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.AttendanceSettings)]
    public static readonly CrudOperation[] BusinessPolicies = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.AttendanceSettings)]
    public static readonly CrudOperation[] NotificationPolicies = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.EmployeeData)]
    public static readonly CrudOperation[] Employees = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.EmployeeData)]
    public static readonly CrudOperation[] BasicEmployees = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.EmployeeData)]
    public static readonly CrudOperation[] ReportingManagers = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.EmployeeData)]
    public static readonly CrudOperation[] Delegations = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.EmployeeData)]
    public static readonly CrudOperation[] PolicyAssignment = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.TimeScheduling)]
    public static readonly CrudOperation[] RequirementMappings = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.TimeScheduling)]
    public static readonly CrudOperation[] ShiftAutoSchedule = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.TimeScheduling)]
    public static readonly CrudOperation[] ShiftManualSchedule = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.TimeScheduling)]
    public static readonly CrudOperation[] ExceptionalShiftSchedule = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.TimeScheduling)]
    public static readonly CrudOperation[] TrainingSchedule = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.TimeScheduling)]
    public static readonly CrudOperation[] TimeSheets = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };


    [Category(CrudPermissionsGenerator.Requests)]
    public static readonly CrudOperation[] LeaveRequests = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.Requests)]
    public static readonly CrudOperation[] PermissionRequests = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.Requests)]
    public static readonly CrudOperation[] RegularizationRequests = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.Requests)]
    public static readonly CrudOperation[] OvertimeRequests = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete
    };

    [Category(CrudPermissionsGenerator.Approvals)]
    public static readonly CrudOperation[] LeavesApproval = new[]
   {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.Approvals)]
    public static readonly CrudOperation[] PermissionsApproval = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.Approvals)]
    public static readonly CrudOperation[] RegularizationsApproval = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.Approvals)]
    public static readonly CrudOperation[] OvertimesApproval = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.UserManagement)]
    public static readonly CrudOperation[] Roles = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete
    };

    [Category(CrudPermissionsGenerator.UserManagement)]
    public static readonly CrudOperation[] SystemUsers = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };

    [Category(CrudPermissionsGenerator.UserManagement)]
    public static readonly CrudOperation[] AzureSetup = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Edit
    };

    [Category(CrudPermissionsGenerator.SettingsSupport)]
    public static readonly CrudOperation[] AuditLogs = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.SettingsSupport)]
    public static readonly CrudOperation[] Translations = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Edit
    };

    [Category(CrudPermissionsGenerator.SettingsSupport)]
    public static readonly CrudOperation[] ApplicationSettings = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Edit
    };

    //[Category(CrudPermissionsGenerator.Reports)]
    //public static readonly CrudOperation[] DailyAttendanceSummary = new[]
    //{
    //    CrudOperation.Page,
    //    CrudOperation.View
    //};

    [Category(CrudPermissionsGenerator.Reports)]
    public static readonly CrudOperation[] AttendanceSummary = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Reports)]
    public static readonly CrudOperation[] MonthlySummary = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Reports)]
    public static readonly CrudOperation[] PunchActivity = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Reports)]
    public static readonly CrudOperation[] LateCount = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Reports)]
    public static readonly CrudOperation[] LateAndEarly = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Reports)]
    public static readonly CrudOperation[] AbsentReport = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Reports)]
    public static readonly CrudOperation[] LeaveReport = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Reports)]
    public static readonly CrudOperation[] EmployeeActivityReport = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Reports)]
    public static readonly CrudOperation[] ManualPunchReport = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Reports)]
    public static readonly CrudOperation[] OverTimeReport = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Reports)]
    public static readonly CrudOperation[] LeaveApprovalReport = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Reports)]
    public static readonly CrudOperation[] PermissionApprovalReport = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Reports)]
    public static readonly CrudOperation[] ManualPunchApprovalReport = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.Reports)]
    public static readonly CrudOperation[] ShiftReport = new[]
    {
        CrudOperation.Page,
        CrudOperation.View
    };

    [Category(CrudPermissionsGenerator.EmployeeData)]
    public static readonly CrudOperation[] DeviceAssignment = new[]
    {
        CrudOperation.Page,
        CrudOperation.View,
        CrudOperation.Create,
        CrudOperation.Edit,
        CrudOperation.Delete,
    };
}