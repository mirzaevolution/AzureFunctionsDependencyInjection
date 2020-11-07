using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Welcome.ServiceAbstracts;

namespace Welcome.App.Triggers
{
    public class ConfigMapHttpTrigger
    {
        private readonly IConfigMapService _configMapService;
        public ConfigMapHttpTrigger(IConfigMapService configMapService)
        {
            _configMapService = configMapService;
        }
        [FunctionName("ConfigMapHttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var dtoList = await _configMapService.GetConfigMaps();
            return new OkObjectResult(dtoList);
        }
    }
}
