## SERVICE BUS

### #11: Posting messages to service bus queue

Create a console app which posts messages (text) to a service bus queue.

[[SOLUTION]](../code-samples/servicebus-queue-send/program.cs)

-----

### #12: Receiving messages from service bus queue

Create a console app which receives/dequeues messages from above service bus queue.

[[SOLUTION]](../code-samples/servicebus-queue-receive/program.cs)

-----

### #13: Publishing to service bus topic

Create a console app which posts messages (text) to a service bus topic.

[[SOLUTION]](../code-samples/servicebus-topic-send/program.cs)

-----

### #14: Subscribing to service bus topics

Create a console app which receives/dequeues messages from above service bus topic.

[[SOLUTION]](../code-samples/servicebus-topic-receive/program.cs)

-----

### #15: ServiceBus queue-triggered function

Create and deploy a function which uses a service bus queue trigger for receiving/processing messages.

[[SOLUTION]](../code-samples/function-app-servicebus-trigger/ServiceBusQueueTriggerFunction.cs)

-----

### #16: ServiceBus topic-triggered function

Create and deploy a function which uses service bus topic + subscription for receiving messages.

[[SOLUTION]](../code-samples/function-app-servicebus-trigger/ServiceBusSubscriptionTriggerFunction.cs)

-----

### #17: ServiceBus output binding (to queue)

Create and deploy a function which writes a message to a service bus queue every 30 seconds.

[[SOLUTION]](../code-samples/function-app-servicebus-output/ServiceBusQueueOutputFunction.cs)

-----

### #18: [HomeWork] ServiceBus output binding (to topic)

Create and deploy a function which writes a message to a service bus topic every 30 seconds.

-----

## COSMOS DB

### #14: Read from and writing to Cosmos DB documents

Create a console app (using .NET Core SDK) that demonstrates simple CRUD actions over Cosmos DB documents.

[solution](../code-samples/cosmos-db-basics/)

-----

### #15: Cosmos DB trigger

[solution](../code-samples/function-app-cosmosdb-trigger/CosmosDBTriggerFunction.cs)

-----

### #16: Cosmos DB trigger (POCO)

[solution](../code-samples/function-app-cosmosdb-trigger/CosmosDBTriggerFunctionAdv.cs)

-----

### #17: Cosmos DB: input binding (sql query)

[solution](../code-samples/function-app-cosmosdb-input/CosmosDBInputFunctionSqlQuery.cs)

-----

### #18: Cosmos DB: input binding (point query)

[solution](../code-samples/function-app-cosmosdb-input/CosmosDBInputFunctionPointQuery.cs)

-----

### #19: Cosmos DB: input binding (binding expression)

[solution](../code-samples/function-app-cosmosdb-input/CosmosDBInputFunctionBindingExpression.cs)

-----

### #20: Cosmos DB: output binding

[solution](../code-samples/function-app-cosmosdb-output/CosmosDBOutputFunctionPointQuery.cs)

-----

### #21: Cosmos DB: output binding (multiple outputs with IAsyncCollector)

[solution](../code-samples/function-app-cosmosdb-output/CosmosDBMultipleOutputFunction.cs)

-----

## Deployment

### #: Create a function app (using Azure CLI)

* First create a resource group.

    ```bash
    az group create --name <resource-group-name> --location eastus2
    ```

* Next, create an Azure storage account within the resource group

    ```bash
    az storage account create \
    --name <storage-account-name> \
    --location eastus2 \
    --resource-group <resource-group-name> \
    --sku Standard_LRS
    ```

* Finally, create the function app inside the resource group

    ```bash
    az functionapp create \
    --name <function-app-name> \
    --storage-account <storage-account-name> \
    --consumption-plan-location eastus2 \
    --resource-group <resource-group-name> \
    --os-type linux --runtime dotnet --functions-version 3
    ```

-----

### #: Deploy a function app (using Azure functions core tools)

* Create an Azure function app (linux) using steps in lab above

* Create a .Net Core 3.1 Timer-triggered function as follows

    ```bash
    mkdir <your-app-name> && cd <your-app-name>

    func init --worker-runtime dotnet

    func new -l C# -n TimerTriggerDemo -t TimerTrigger
    ```

* Modify the timer-trigger CRON expression as needed

* Finally, deploy the app

    ```bash
    func azure functionapp publish <function-app-name>
    ```

-----

### #: Deploy a function app (using Azure DevOps Pipeline)

* Create a service principal in Azure AD (via Azure Portal).

* Add the service principal to `contributor` role.

* Create a service connection in Azure DevOps using above service principal.

* Create a function app (using steps from lab above) and checkin to Azure Repos.

* Create a new YAML build pipeline via Azure DevOps portal.

* Add `dotnet build` task.

* Add `dotnet publish` task (ensure that `publishWebProjects` is set to false and `**/*.csproj` is specified as project path).

* Add `azure functions` task for deployment of above published package.

-----

## Monitoring

### #: KQL Query

Extract the top 20 most time-consuming function app executions in the last 4 hours.

```bash
requests
| where timestamp > ago(30d)
| where cloud_RoleName =~ '<@replace-function-app-name>' and operation_Name =~ '<@replace-function-name>'
| order by timestamp desc
| take 20
```

-----

### #: KQL Query (with nested properties)

Same query as above but using execution time reported in customDimension property.

```bash
requests
| where timestamp > ago(30d)
| where cloud_RoleName =~ '<@replace-function-app-name>' and operation_Name =~ '<@replace-function-name>'
| project actualTime=todouble(customDimensions.FunctionExecutionTimeMs), cloud_RoleName, cloud_RoleInstance
| order by actualTime desc
| take 20
```

-----

### #: Metric-based Alerts

Create a metrics-based alert to email you when total blobs in a storage account exceed (say) 5.

-----

## Logic Apps

-----

## Durable Functions

### #: Chaining example

-----

### #: Fan-in / fan-out example

-----

### #: Long-running HTTP request

-----

## Unit Testing

### #: @todo

-----
