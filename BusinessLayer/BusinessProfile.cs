using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Models;

namespace BusinessLayer
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMapper();
        }

        private void CreateMapper()
        {
            CreateMap<DataEntity, BaseInfo>();
            CreateMap<Company, CompanyInfo>();
            CreateMap<Employee, EmployeeInfo>()
                //Custom mappings
                .ForMember(des=>des.OccupationName, act => act.MapFrom(src => src.Occupation))
                .ForMember(des=>des.PhoneNumber, act => act.MapFrom(src => src.Phone))
                .ForMember(des=>des.LastModifiedDateTime, act => act.MapFrom(src => src.LastModified))
                .ForMember(des=>des.CompanyName, act => act.MapFrom(src => src.CompanyCode));
            CreateMap<EmployeeInfo, Employee>()
               .ForMember(des => des.Occupation, act => act.MapFrom(src => src.OccupationName))
               .ForMember(des => des.Phone, act => act.MapFrom(src => src.PhoneNumber))
               .ForMember(des => des.LastModified, act => act.MapFrom(src => src.LastModifiedDateTime))
               .ForMember(des => des.CompanyCode, act => act.MapFrom(src => src.CompanyName));
            CreateMap<ArSubledger, ArSubledgerInfo>();
        }
    }

}