using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ConfigMapDto> GetConfigMapById(string id)
        {
            var entity = await _dbContext.ConfigMaps.FirstOrDefaultAsync(c => c.Id.ToLower() == id.ToLower());
            var dto = _mapper.Map<ConfigMap, ConfigMapDto>(entity);
            return dto;
        }

        public async Task<List<ConfigMapDto>> GetConfigMaps()
        {
            var entities = await _dbContext.ConfigMaps.ToListAsync();
            var dtoList = _mapper.Map<List<ConfigMap>, List<ConfigMapDto>>(entities);
            return dtoList;
        }

        public async Task<List<ConfigMapDto>> GetConfigMapsByKey(string key)
        {
            var entities = await _dbContext.ConfigMaps.Where(c => c.Key.Contains(key)).ToListAsync();
            var dtoList = _mapper.Map<List<ConfigMap>, List<ConfigMapDto>>(entities);
            return dtoList;
        }
    }
}
