using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Domain.Entities;
using TaskUser.Domain.Repositories;

namespace TaskUser.Infrastructure.Data.Repositories
{
    public class UserLoginAttempRepository : RepositoryBase<UserLoginAttempt>, IUserLoginAttempRepository
    {
        public UserLoginAttempRepository(EFDbContext ctx) : base(ctx)
        {
        }
    }
}
