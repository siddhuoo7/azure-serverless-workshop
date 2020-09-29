using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class CosmosDBTriggerFunction
    {
        [FunctionName("CosmosDBTriggerFunction")]
        public static void Run([CosmosDBTrigger("mydb1", "mycontainer1",
            ConnectionStringSetting = "AzureWebJobsCosmosDB",
            CreateLeaseCollectionIfNotExists = true)]
            IReadOnlyList<Document> documents,
            ILogger log)
        {
            log.LogInformation($"Documents created/modified = {documents.Count}");

            foreach(var document in documents)
            {
                log.LogInformation($"id: {document.Id}");
            }
        }
    }
}
