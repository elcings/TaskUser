using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Domain.Base;

namespace TaskUser.Domain.Entities
{
    public class User:BaseEntity
    {
        public User()
        {
            Attempts = new HashSet<UserLoginAttempt>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserLoginAttempt> Attempts { get; set; }
    }
}
