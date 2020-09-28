using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public static class HttpTriggerFunction
    {
        [FunctionName("HttpTriggerFunction")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            // note the app setting key must be of the format: @Microsoft.KeyVault(SecretUri=@replace-with-secret-uri)
            var secretName = "@replace-with-app-setting";
            var secretValue = Environment.GetEnvironmentVariable(secretName, EnvironmentVariableTarget.Process);

            log.LogInformation($"The value of the key vault secret `{secretName}` is `{secretValue ?? "undefined"}`");
            return new OkObjectResult(secretValue);
        }
    }
}
