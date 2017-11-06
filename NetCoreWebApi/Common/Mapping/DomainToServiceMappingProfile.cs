using AutoMapper;
using NetCoreModel;
using NetCoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Common.Mapping
{
    public class DomainToServiceMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToServiceMappingProfile";
            }
        }

        public DomainToServiceMappingProfile()
        {
            CreateMap<TestModel, TestViewModel>()
                    .ForMember(x => x.NameDisplay, opt => opt.MapFrom(source => source.Name));

            //Mapper.AssertConfigurationIsValid();
        }
    }
}
