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
            // notes: 
            // - The value of the app setting must be of the format: @Microsoft.KeyVault(SecretUri=@replace-with-secret-uri)
            // - If using versionless secret URI, then ensure trailing forward-slash '/' present.
            // - Key Vault references do not work locally (https://github.com/Azure/azure-functions-host/issues/3907).
            var secretName = "@replace-with-app-setting";
            var secretValue = Environment.GetEnvironmentVariable(secretName, EnvironmentVariableTarget.Process);

            log.LogInformation($"The value of the key vault secret `{secretName}` is `{secretValue ?? "undefined"}`");
            return new OkObjectResult(secretValue);
        }
    }
}
