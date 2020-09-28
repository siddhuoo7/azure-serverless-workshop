using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public class TimerTriggerFunction
    {
        private readonly IConfiguration _configuration;

        public TimerTriggerFunction(IConfiguration config)
        {
            this._configuration = config;
        }

        [FunctionName("TimerTriggerFunction")]
        public void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            // var content = await this._client.GetStringAsync("https://www.cnn.com");
            // log.LogInformation(content);

            var val = this._configuration["mysecret1"];
            log.LogInformation($"mysecret1: {this._configuration["mysecret1"]}");
        }
    }
}
