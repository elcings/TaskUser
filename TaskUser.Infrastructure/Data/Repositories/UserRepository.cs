using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Domain.Entities;
using TaskUser.Domain.Repositories;

namespace TaskUser.Infrastructure.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(EFDbContext ctx) : base(ctx)
        {
        }
    }
}
