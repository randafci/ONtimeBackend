using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OnTime.User.Services.DTO;
using OnTime.User.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;
namespace OnTime.User.Services.Implementation
{
 
    public class SettingsProvider : ISettingsProvider
    {
        private readonly IOptions<LdapOptions> _ldapOptions;

        public SettingsProvider(IOptions<LdapOptions> ldapOptions)
        {
            _ldapOptions = ldapOptions;
        }

        public Task<LdapOptions> GetLdapSettings(CancellationToken cancellationToken = default)
        {
            // Return a copy to avoid accidental external updates
            var copy = new LdapOptions
            {
                IsActive = _ldapOptions.Value.IsActive,
                LdapServer = _ldapOptions.Value.LdapServer,
                LdapDomain = _ldapOptions.Value.LdapDomain,
                LdapUsername = _ldapOptions.Value.LdapUsername,
                LdapPassword = _ldapOptions.Value.LdapPassword,
                LdapEmpAttr = _ldapOptions.Value.LdapEmpAttr
            };

            return Task.FromResult(copy);
        }
    }

}
