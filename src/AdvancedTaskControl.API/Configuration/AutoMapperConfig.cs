using AdvancedTaskControl.API.Models;
using AdvancedTaskControl.API.ViewModels;
using AdvancedTaskControl.Business.Models;
using AutoMapper;

namespace AdvancedTaskControl.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<UserLoginModelView, User>();

            CreateMap<UserTask, UserTaskViewModel>().ReverseMap();
        }
    }
}
