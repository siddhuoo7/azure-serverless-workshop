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
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public static class CosmosDBInputFunction
    {
        [FunctionName("CosmosDBInputFunction")]
        public static void Run(
            [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
            [CosmosDB("mydb1", "mycontainer1",
                ConnectionStringSetting = "AzureWebJobsCosmosDB",
                SqlQuery = "select * from c")]
                IEnumerable<Contact> contacts,
            ILogger log)
        {
            foreach (var contact in contacts)
            {
                log.LogInformation($"document: {JsonConvert.SerializeObject(contact)}");
            }
        }
    }
}
