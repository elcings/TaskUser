using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskUser.Application.DTO
{
    public class UserLoginAttempDTO
    {
        public Guid Id { get; set; }
        public DateTime AttempTime { get; set; }
        public Guid UserId { get; set; }
        public UserDTO User { get; set; }
    }
}
