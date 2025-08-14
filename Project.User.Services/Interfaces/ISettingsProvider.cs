using OnTime.User.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.User.Services.Interfaces
{
    public interface ISettingsProvider
    {
        Task<LdapOptions> GetLdapSettings(CancellationToken cancellationToken = default);
    }
}
