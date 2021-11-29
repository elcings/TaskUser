using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Application.DTO;

namespace TaskUser.Application.BusinesLogic
{
    public interface IUserBusinessLogic
    {
        List<UserDTO> GetAll();
        UserDTO GetById(Guid Id);
        UserDTO Save(UserDTO dto);
        void Remove(Guid Id);
    }
}
