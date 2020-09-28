using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class CosmosDBOutputFunctionSqlQuery
    {
        [FunctionName("CosmosDBOutputFunctionSqlQuery")]
        public static void UseSqlQuery(
            [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
            [CosmosDB("mydb1", "mycontainer1", // replace later as appropriate
                ConnectionStringSetting = "AzureWebJobsCosmosDB",
                SqlQuery = "select * from c")] // replace later as appropriate
                IEnumerable<Contact> contacts,
            ILogger log)
        {
            foreach (var contact in contacts)
            {
                contact.FirstName = "Leonardo";
            }
        }
    }
}
