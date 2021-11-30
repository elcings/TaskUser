using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Application.DTO;
using TaskUser.Common.Model;

namespace TaskUser.Application.BusinesLogic
{
    public interface IUserLoginAttemptBusinessLogic
    {
        List<UserLoginAttempDTO> GetAll();
        UserLoginAttempDTO GetById(Guid Id);
        StatisticReponse Get(StatisticRequest request);
        UserLoginAttempDTO Save(UserLoginAttempDTO dto);
        void Remove(Guid Id);
    }
}
