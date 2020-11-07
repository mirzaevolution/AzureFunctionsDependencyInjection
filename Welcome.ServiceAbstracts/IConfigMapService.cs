using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Welcome.DataTransferObjects;

namespace Welcome.ServiceAbstracts
{
    public interface IConfigMapService
    {
        Task<List<ConfigMapDto>> GetConfigMaps();
    }
}
