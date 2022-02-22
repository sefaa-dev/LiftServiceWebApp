using AutoMapper;
using LiftServiceWebApp.Models.Entities;
using LiftServiceWebApp.ViewModels;

namespace LiftServiceWebApp.MapperProfiles
{
    public class FailureProfile : Profile
    {
        public FailureProfile()
        {
            CreateMap<Failure, FailureViewModel>().ReverseMap();
        }
    }
}
