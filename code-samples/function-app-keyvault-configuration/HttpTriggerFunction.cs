using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public class HttpTriggerFunction
    {
        private readonly IConfiguration _configuration;

        public HttpTriggerFunction(IConfiguration config)
        {
            this._configuration = config;
        }

        [FunctionName("HttpTriggerFunction")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var secretName = "@replace-with-app-setting"; // replace later as needed
            var secretValue = this._configuration[secretName];

            log.LogInformation($"The value of the key vault secret `{secretName}` is `{secretValue ?? "undefined"}`");
            return new OkObjectResult(secretValue);
        }
    }
}
