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
        [FunctionName(nameof(GetAll))]
        public async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ConfigMap/GetAll")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"{nameof(GetAll)} - receives request");
            try
            {
                var dtoList = await _configMapService.GetConfigMaps();
                return new OkObjectResult(dtoList);
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }
        [FunctionName(nameof(GetById))]
        public async Task<IActionResult> GetById(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ConfigMap/GetById/{id}")] HttpRequest req,
                string id,
                ILogger log
            )
        {
            log.LogInformation($"{nameof(GetById)} - receives request");
            try
            {
                var dto = await _configMapService.GetConfigMapById(id);
                return new OkObjectResult(dto);
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }
        [FunctionName(nameof(GetByKey))]
        public async Task<IActionResult> GetByKey(
              [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ConfigMap/GetByKey/{key}")] HttpRequest req,
              string key,
              ILogger log
          )
        {
            log.LogInformation($"{nameof(GetByKey)} - receives request");
            try
            {
                var dtoList = await _configMapService.GetConfigMapsByKey(key);
                return new OkObjectResult(dtoList);
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }
    }
}
