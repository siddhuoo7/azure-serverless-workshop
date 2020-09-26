// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace function_app_eventgrid_trigger
{
    public static class EventGridTriggerFunction
    {
        // [FunctionName("EventGridTriggerFunction")]
        // public static void Run(
        //     [EventGridTrigger] EventGridEvent eventGridEvent,
        //     ILogger log)
        // {
        //     log.LogInformation(eventGridEvent.Data.ToString());
        // }

        [FunctionName("EventGridTriggerFunction")]
        public static async Task Run(
            [EventGridTrigger] EventGridEvent eventGridEvent,
            [EventGrid(TopicEndpointUri = "AzureWebJobsTopicEndpointUri", TopicKeySetting = "AzureWebJobsTopicKeySetting")] IAsyncCollector<EventGridEvent> collector,
            ILogger log)
        {
            log.LogInformation(eventGridEvent.Data.ToString());
            await collector.AddAsync(eventGridEvent);
        }
    }
}
