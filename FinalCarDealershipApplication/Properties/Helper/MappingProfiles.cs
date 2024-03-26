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
        }
    }
}
