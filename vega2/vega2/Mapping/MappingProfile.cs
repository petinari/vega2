using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega2.Controllers.Resources;
using vega2.Models;

namespace vega2.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResources>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            
            
        }
    }
}
