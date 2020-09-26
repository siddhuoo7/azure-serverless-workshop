using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public class Contact
    {
        public string FirstName {get; set; }

        public string LastName {get; set; }

        [JsonProperty("id")]
        public string Id {get; set;}
    }

    public static class CosmosDBTriggerFunctionAdv
    {
        [FunctionName("CosmosDBTriggerFunctionAdv")]
        public static void Run([CosmosDBTrigger("mydb1", "mycontainer1",
            ConnectionStringSetting = "AzureWebJobsCosmosDB",
            CreateLeaseCollectionIfNotExists = true)]
            IReadOnlyList<Contact> contacts,
            ILogger log)
        {
            if (contacts != null && contacts.Count > 0)
            {
                log.LogInformation("Documents modified " + contacts.Count);
                log.LogInformation("First document Id " + contacts[0].Id);
            }
        }
    }
}
