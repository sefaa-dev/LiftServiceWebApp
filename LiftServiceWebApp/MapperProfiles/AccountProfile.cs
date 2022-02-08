using AutoMapper;
using LiftServiceWebApp.Models.Identity;
using LiftServiceWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.MapperProfiles
{
       public class AccountProfile : Profile
        {
            public AccountProfile()
            {
                CreateMap<ApplicationUser, UserProfileViewModel>().ReverseMap();
            }
        }
    }