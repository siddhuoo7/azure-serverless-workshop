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
        public static void Run([CosmosDBTrigger("mydb1", "mycollection1",
            ConnectionStringSetting = "AzureWebJobsCosmosDB",
            CreateLeaseCollectionIfNotExists = true)]
            IReadOnlyList<Document> documents,
            ILogger log)
        {
            log.LogInformation($"Documents created/modified = {documents.Count}");

            foreach(var document in documents)
            {
                var contact = JsonConvert.DeserializeObject<Contact>(document.ToString());
                log.LogInformation($"document: {JsonConvert.SerializeObject(contact)}");
            }
        }
    }
}
