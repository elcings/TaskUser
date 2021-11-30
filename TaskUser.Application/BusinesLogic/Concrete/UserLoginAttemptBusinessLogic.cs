using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Application.BusinesLogic;
using TaskUser.Application.DTO;
using TaskUser.Common.Model;
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


      

        public StatisticReponse Get(StatisticRequest request)
        {
            var query = _userLoginAttempRepository.Query().Select(x=>new {Year=x.AttemptTime.Year,Month=x.AttemptTime.Month,Day=x.AttemptTime.Day,IsSucced=x.IsSuccess,UserId=x.UserId }).ToList();
            var result = new StatisticReponse();
            query.GroupBy(x => new
            {
                Year = x.Year
            }).Select(x =>new
            {
                 Year = x.Key.Year,
                 Count = x.Count()
            }).ToList().ForEach(x=> {
                result.Year.Add(new Data { Period = x.Year, Value = x.Count });
            });

           query.GroupBy(x => new
            {
                Year=x.Year,
                Month = x.Month
            }).Select(x => new
            {
                Year = x.Key.Year,
                Month = x.Key.Month,
                Count = x.Count()
            }).ToList().ForEach(x => {
                result.Month.Add(new Data { Period = $"{x.Month}.{x.Year}", Value = x.Count });
            }); 
             query.GroupBy(x => new
            {
                Year=x.Year,
                Month=x.Month,
                Day = x.Day
            })
          .Select(grp => new
          {
              Year=grp.Key.Year,
              Month=grp.Key.Month,
              Day = grp.Key.Day,
              Count = grp.Count()
          }).ToList().ForEach(x => {
              result.Day.Add(new Data { Period = $"{x.Month}.{x.Year}.{x.Day}", Value = x.Count });
          });

            return result;
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
