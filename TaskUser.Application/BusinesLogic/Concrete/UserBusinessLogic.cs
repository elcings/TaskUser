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
    public class UserBusinessLogic : IUserBusinessLogic
    {
        private IUserRepository _userRepository;
        IMapper _mapper;
        public UserBusinessLogic(IUserRepository userRepository,   IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<UserDTO> GetAll()
        {
            var all = _userRepository.GetAll();
            return _mapper.Map<List<UserDTO>>(all);
        }

        public UserDTO GetById(Guid Id)
        {
            var entity = _userRepository.GetById(Id);
            return _mapper.Map<UserDTO>(entity);
        }

        public void Remove(Guid Id)
        {
            _userRepository.Remove(Id);
        }

        public UserDTO Save(UserDTO dto)
        {
            var entity = _mapper.Map<User>(dto);

            if (entity.Id == Guid.Empty)
            {
                _userRepository.Create(entity);
            }
            else
                _userRepository.Update(entity);

            return _mapper.Map<UserDTO>(entity);
        }
    }
}
