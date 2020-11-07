using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Welcome.DataAccessLayer;
using Welcome.DataEntities;
using Welcome.DataTransferObjects;
using Welcome.ServiceAbstracts;

namespace Welcome.Services
{
    public class ConfigMapService : IConfigMapService
    {
        private readonly WelcomeDbContext _dbContext;
        private readonly IMapper _mapper;
        public ConfigMapService(WelcomeDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public async Task<List<ConfigMapDto>> GetConfigMaps()
        {
            var entities = await _dbContext.ConfigMaps.ToListAsync();
            var dtoList = _mapper.Map<List<ConfigMap>, List<ConfigMapDto>>(entities);
            return dtoList;
        }
    }
}
