using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARMSBackend.DTOs;
using ARMSBackend.Models;
using AutoMapper;

namespace ARMSBackend.Profiles
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
            CreateMap<UserWriteDto, User>();
            CreateMap<User, UserReadDto>();
            CreateMap<User, UserEditDto>();
        }
    }
}
