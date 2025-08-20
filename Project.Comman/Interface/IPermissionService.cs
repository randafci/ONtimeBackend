using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnTime.Common.Interfaces
{
public interface IPermissionService
{
    Task<List<string>> GetUserPermissions(string userId);
}
}
