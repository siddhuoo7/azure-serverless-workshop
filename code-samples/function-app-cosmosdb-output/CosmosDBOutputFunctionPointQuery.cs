using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class CosmosDBOutputFunctionPointQuery
    {
        [FunctionName("CosmosDBOutputFunction")]
        public static void UsePointQuery(
            [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
            [CosmosDB("mydb1", "mycollection1", // replace later as appropriate
                ConnectionStringSetting = "AzureWebJobsCosmosDB",
                PartitionKey = "12345", // replace later as appropriate
                Id= "12345")] // replace later as appropriate
                Contact contact,
            ILogger log)
        {
            if (contact != null)
            {
                contact.FirstName = "Leonardo";
            }
        }
    }
}
