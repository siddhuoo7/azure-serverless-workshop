using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class CosmosDBInputFunctionSqlQuery
    {
        [FunctionName("CosmosDBInputFunctionSqlQuery")]
        public static void UseSqlQuery(
            [TimerTrigger("*/30 * * * * *")] TimerInfo myTimer,
            [CosmosDB("mydb1", "mycollection1",
                ConnectionStringSetting = "AzureWebJobsCosmosDB",
                SqlQuery = "select * from c")] // replace later as appropriate
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
