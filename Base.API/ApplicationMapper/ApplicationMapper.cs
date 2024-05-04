using AutoMapper;
using Base.Repositories.Models;
using Base.Services.ViewModel.RequestVM;
using Base.Services.ViewModel.ResponseVM;

namespace Base.API.ApplicationMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Product, ProductResponse>().ForMember(dest => dest.CategoryName, opt => opt
                                            .MapFrom(src => src.Category!.CategoryName))
                                            .ReverseMap();
            CreateMap<Product, ProductVM>().ReverseMap();
            CreateMap<User, UserResponse>().ForMember(dest => dest.RoleName, opt => opt
                                           .MapFrom(src => src.Role!.RoleName))
                                           .ReverseMap();
        }
    }
}
