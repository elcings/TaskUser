using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(5, ErrorMessage = "Name length can't be more than 5.")]
        public string Name { get; set; }
        [MaxLength(30, ErrorMessage = "Surname length can't be more than 30.")]
        public string Surname { get; set; }
        [MaxLength(25, ErrorMessage = "Email length can't be more than 25.")]
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public ICollection<UserLoginAttempDTO> AttempDTOs { get; set; }
    }
}
