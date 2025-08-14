using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.User.Services.DTO
{
    public record UserRefreshToken(string UserId, string RefreshToken);
}
