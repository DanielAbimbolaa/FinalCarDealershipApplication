using AutoMapper;
using FinalCarDealershipApplication.Dto;
using FinalCarDealershipApplication.Models;

namespace FinalCarDealershipApplication.Helper
{
    public class MappingProfiles : Profile 
    {
        public MappingProfiles()
        {
            CreateMap<Cars, CarDto>();
            CreateMap<CarDto, Cars>();
            CreateMap<Admins, AdminDto>();
            CreateMap<AdminDto, Admins>();
            CreateMap<Customers, CustomerDto>();
            CreateMap<CustomerDto, Customers>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Sales, SaleDto>();
            CreateMap<SaleDto, Sales>();
        }
    }
}
