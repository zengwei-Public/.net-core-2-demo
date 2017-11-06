using AutoMapper;
using NetCoreModel;
using NetCoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Common.Mapping
{
    public class ServiceToDomainMappingProfile : Profile
    {

        public ServiceToDomainMappingProfile()
        {
            CreateMap<TestViewModel, TestModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(source => source.NameDisplay));
        }
    }
}
