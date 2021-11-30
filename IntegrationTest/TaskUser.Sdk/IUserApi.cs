using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Application.DTO;
using TaskUser.Common;

namespace TaskUser.Sdk
{
    public interface IUserApi
    {
        [Get("/api/User/{email}")]
        Task<UserDTO> GetByEmail(string email,[Header("ApiKey")]string key);
    }
}
