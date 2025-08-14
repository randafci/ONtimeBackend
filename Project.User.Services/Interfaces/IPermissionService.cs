namespace OnTime.User.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IPermissionService
{
    Task<List<string>> GetUserPermissions(string userId);
}

