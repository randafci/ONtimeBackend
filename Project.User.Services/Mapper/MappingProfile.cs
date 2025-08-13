using AutoMapper;
using OnTime.Comman.Idenitity;
using OnTime.Data.Entities;
using OnTime.Services.DataTransferObject.AuthenticationDto;
using OnTime.Services.DataTransferObject.Customer;
namespace OnTime.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
         
            CreateMap<RegisterUserDto, ApplicationUser>()
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<ApplicationUser, GetUserDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserName)).ReverseMap();

            CreateMap<Customer, CustomerGetAllModel>().ReverseMap();
            CreateMap<Customer, CustomerSearchModel>().ReverseMap();
            CreateMap<CustomerCreateModel, Customer>().ReverseMap();

        }
    }
}
