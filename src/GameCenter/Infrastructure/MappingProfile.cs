using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameCenter.DAL.Entities;
using GameCenter.Models;

namespace GameCenter.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseEntity, BaseModel>()
                .Include<User, UserModel>()
                .Include<ApplicationDescription, ApplicationDescriptionModel>();

            CreateMap<User, UserModel>();
            CreateMap<ApplicationDescription, ApplicationDescriptionModel>();
        }
    }
}
