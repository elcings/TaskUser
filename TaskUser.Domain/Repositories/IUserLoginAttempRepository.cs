using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Domain.Entities;

namespace TaskUser.Domain.Repositories
{
    public interface IUserLoginAttempRepository:IRepository<UserLoginAttempt>
    {
    }
}
