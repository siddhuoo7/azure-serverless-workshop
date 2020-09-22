# Labs: Azure Serverless Workshop

## Basic Concepts - Triggers & Bindings

### #: Timer-triggered function app

Create & deploy a function app that triggers on the 15th and 45th second of every second minute.

[[SOLUTION]](../code-samples/function-app-mixed/TimerTriggerFunction.cs)

-----

### #: Http-triggered function app

Create & deploy a function app that processes a `POST` request as follows:

* Accepts a request for weather information of specified city (see format below):

    ```json
    {
        "city": "Bangalore"
    }
    ```

* Returns weather information for last 7 days for specified city (see format below):

    ```json
    {
        "city": "Bangalore",
        "dailyReport": [
            {
                "date": "2020-09-02T00:00:00+05:30",
                "celciusHigh": 40,
                "celciusLow": 30
            },
            {
                "date": "2020-09-01T00:00:00+05:30",
                "celciusHigh": 39,
                "temperatureLowCelcius": 28
            },
            {
                "date": "2020-08-31T00:00:00+05:30",
                "celciusHigh": 38,
                "temperatureLowCelcius": 27
            },
            {
                "date": "2020-08-30T00:00:00+05:30",
                "celciusHigh": 37,
                "temperatureLowCelcius": 26
            },
            {
                "date": "2020-08-29T00:00:00+05:30",
                "celciusHigh": 36,
                "temperatureLowCelcius": 25
            },
            {
                "date": "2020-08-28T00:00:00+05:30",
                "celciusHigh": 35,
                "temperatureLowCelcius": 24
            },
            {
                "date": "2020-08-27T00:00:00+05:30",
                "celciusHigh": 34,
                "temperatureLowCelcius": 23
            }
        ]
    }
    ```

[[SOLUTION]](../code-samples/function-app-mixed/HttpTriggerFunctionAdv.cs)

-----

### #: Data-triggered function app

Create & deploy a function app that processes blobs uploaded to a storage account's container.

[[SOLUTION]](../code-samples/function-app-mixed/BlobTriggerFunction.cs)

-----

### #: Output binding

Create & deploy a function app that create a new blob (in a storage account's container) every minute.

[[SOLUTION]](../code-samples/function-app-mixed/BlobOutputFunction.cs)

-----

### #: Runtime binding

Same example as above, but output blob names should be in the format: `yyyy-MM-dd-HH-mm-ss.txt`

[[SOLUTION]](../code-samples/function-app-mixed/BlobRuntimeBindingFunction.cs)

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
    --resource-group azsrvwkrg2 \
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
