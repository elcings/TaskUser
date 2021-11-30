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
        private IUserLoginAttempRepository _userLoginAttempRepository;
        IMapper _mapper;
        public UserBusinessLogic(IUserRepository userRepository,   IMapper mapper, IUserLoginAttempRepository userLoginAttempRepository)
        {
            _userRepository = userRepository;
            _userLoginAttempRepository = userLoginAttempRepository;
            _mapper = mapper;
        }

        public List<UserDTO> GetAll()
        {
            var all = _userRepository.GetAll();
            return _mapper.Map<List<UserDTO>>(all);
        }

        public UserDTO GetByEmail(string email)
        {
            var entity = _userRepository.Query(f => f.Email.Equals(email), includeProperties: "Attempts").FirstOrDefault();
            return _mapper.Map<UserDTO>(entity);
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

        public UserDTO Create(UserDTO dto)
        {
            var entity = _mapper.Map<User>(dto);
            _userRepository.Create(entity);
            return _mapper.Map<UserDTO>(entity);
        }

        public void Init()
        {
            var users = _userRepository.GetAll();
            if (users.Any())
            {
                _userRepository.RemoveAll(users);
            }
            var rand = new Random();
            var user1 = new User { Id = Guid.NewGuid(), Name = $"{rand.Next(0, 100)}Name", Surname = $"{rand.Next(0, 100)}Surname", Email = $"{rand.Next(0, 100)}Email@gmail.com" };
            var attemptList1 = new List<UserLoginAttempt>();
            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                    attemptList1.Add(new UserLoginAttempt { Id = Guid.NewGuid(), AttemptTime = DateTime.Now, IsSuccess = true, UserId = user1.Id });
                else
                    attemptList1.Add(new UserLoginAttempt { Id = Guid.NewGuid(), AttemptTime = DateTime.Now, IsSuccess = false, UserId = user1.Id });
            }
            user1.Attempts = attemptList1;

            var user2 = new User { Id = Guid.NewGuid(), Name = $"{rand.Next(0, 100)}Name", Surname = $"{rand.Next(0, 100)}Surname", Email = $"{rand.Next(0, 100)}Email@gmail.com" };

            var userList = new List<User>();

            var attemptList2 = new List<UserLoginAttempt>();
            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                    attemptList2.Add(new UserLoginAttempt { Id = Guid.NewGuid(), AttemptTime = DateTime.Now, IsSuccess = true, UserId = user1.Id });
                else
                    attemptList2.Add(new UserLoginAttempt { Id = Guid.NewGuid(), AttemptTime = DateTime.Now, IsSuccess = false, UserId = user1.Id });
            }
            user2.Attempts = attemptList2;
            userList.Add(user1);
            userList.Add(user2);
            _userRepository.CreateList(userList);

        }
    }
}
