using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskUser.Application.DTO
{
   public class UserDTO
    {
        public UserDTO()
        {
            AttempDTOs = new HashSet<UserLoginAttempDTO>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public ICollection<UserLoginAttempDTO> AttempDTOs { get; set; }
    }
}
