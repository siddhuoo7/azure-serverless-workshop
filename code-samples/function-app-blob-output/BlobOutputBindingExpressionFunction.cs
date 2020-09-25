using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public static class BlobOutputBindingExpressionFunction
    {
        [FunctionName("BlobOutputBindingExpressionFunction")]
        public static void Run(
            [TimerTrigger("0 */1 * * * *")] TimerInfo myTimer,
            [Blob("mycontainer1/foo-{datetime}.txt", FileAccess.Write)] out string contentToWrite,
            [Blob("mycontainer1/bar-{rand-guid}.txt", FileAccess.Write)] out string contentToWrite,
            ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            contentToWrite = $"C# Timer trigger function executed at: {DateTime.Now}";
        }
    }
}
