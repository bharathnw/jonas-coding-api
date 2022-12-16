using AutoMapper;
using BusinessLayer.Model.Models;
using WebApi.Models;

namespace WebApi
{
    public class AppServicesProfile : Profile
    {
        public AppServicesProfile()
        {
            CreateMapper();
        }

        private void CreateMapper()
        {
            CreateMap<BaseInfo, BaseDto>();
            CreateMap<CompanyInfo, CompanyDto>();
            CreateMap<CompanyDto, CompanyInfo>();
            CreateMap<EmployeeInfo, EmployeeDTO>()
                .ForMember(des => des.OccupationName, act => act.MapFrom(src => src.OccupationName))
                .ForMember(des => des.PhoneNumber, act => act.MapFrom(src => src.PhoneNumber))
                .ForMember(des => des.LastModifiedDateTime, act => act.MapFrom(src => src.LastModifiedDateTime))
                .ForMember(des => des.CompanyName, act => act.MapFrom(src => src.CompanyCode));
            CreateMap<ArSubledgerInfo, ArSubledgerDto>();
        }
    }
}