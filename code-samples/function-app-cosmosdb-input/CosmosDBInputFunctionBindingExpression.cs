using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApp
{
    public static class CosmosDBInputFunctionBindingExpression
    {
        [FunctionName("CosmosDBInputFunctionBindingExpression")]
        public static void UseBindingExpression(
            [BlobTrigger("myblobcontainer1/{blobName}")] string blob, // replace later as appropriate
            [CosmosDB("contactsdb", "contactscontainer",
                ConnectionStringSetting = "AzureWebJobsCosmosDB",
                SqlQuery = "select * from c where c.lastName = {blobName}")] // replace later as appropriate
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
