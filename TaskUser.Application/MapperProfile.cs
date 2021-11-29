using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Application.DTO;
using TaskUser.Domain.Entities;

namespace TaskUser.Application
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserLoginAttempt, UserLoginAttempDTO>().ReverseMap();
        }
    }
}
