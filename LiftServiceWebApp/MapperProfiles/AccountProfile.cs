using AutoMapper;
using LiftServiceWebApp.Models.Identity;
using LiftServiceWebApp.ViewModels;

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