using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Welcome.DataEntities;
using Welcome.DataTransferObjects;

namespace Welcome.App
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            RegisterConfigMap();
        }
        private void RegisterConfigMap()
        {
            CreateMap<ConfigMap, ConfigMapDto>().ReverseMap();
        }
    }
}
