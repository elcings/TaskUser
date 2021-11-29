using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Domain.Base;

namespace TaskUser.Domain.Entities
{
    public class UserLoginAttempt : BaseEntity
    {
        public DateTime AttemptTime { get; set; }
        public bool IsSuccess { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
