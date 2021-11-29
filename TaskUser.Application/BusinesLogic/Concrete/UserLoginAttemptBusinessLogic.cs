using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Application.BusinesLogic;
using TaskUser.Application.DTO;
using TaskUser.Domain.Entities;
using TaskUser.Domain.Repositories;

namespace TaskUser.Application.BusinesLogic
{
    public class UserLoginAttemptBusinessLogic : IUserLoginAttemptBusinessLogic
    {

        private IUserLoginAttempRepository _userLoginAttempRepository;
        IMapper _mapper;
        public UserLoginAttemptBusinessLogic(IUserLoginAttempRepository userLoginAttempRepository, IMapper mapper)
        {
            _userLoginAttempRepository = userLoginAttempRepository;
            _mapper = mapper;
        }

        public List<UserLoginAttempDTO> GetAll()
        {
            var all = _userLoginAttempRepository.GetAll();
            return _mapper.Map<List<UserLoginAttempDTO>>(all);
        }

        public UserLoginAttempDTO GetById(Guid Id)
        {
            var entity = _userLoginAttempRepository.GetById(Id);
            return _mapper.Map<UserLoginAttempDTO>(entity);
        }

        public void Remove(Guid Id)
        {
            _userLoginAttempRepository.Remove(Id);
        }

        public UserLoginAttempDTO Save(UserLoginAttempDTO dto)
        {
            var entity = _mapper.Map<UserLoginAttempt>(dto);

            _userLoginAttempRepository.Create(entity);

            return _mapper.Map<UserLoginAttempDTO>(entity);
        }
    }
}
