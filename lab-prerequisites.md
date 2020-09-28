# Prerequisites for labs

* Please ensure that you have access to an active Azure subscription.
* Install Azure CLI ([instructions](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest))
  * Log into Azure CLI with your Azure credentials: `az login`
  * Set the default azure subscription to use: `az account set -s <your-subscription-id>`
* Install .NET Core 3.1 SDK ([instructions](https://dotnet.microsoft.com/download/dotnet-core/3.1))
* Install VSCode ([download](https://code.visualstudio.com/))
* Install the following VSCode Extensions:
  * CSharp: [download link](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) | `code --install-extension ms-dotnettools.csharp`
  * Azure Account: [download link](https://marketplace.visualstudio.com/items?itemName=ms-vscode.azure-account) | `code --install-extension ms-vscode.azure-account`
  * Azure Tools: [download link](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-node-azure-pack) | `code --install-extension ms-vscode.vscode-node-azure-pack`
  * SQL Server: [download link](https://marketplace.visualstudio.com/items?itemName=ms-mssql.mssql) | `code --install-extension ms-mssql.mssql`
  * ARM (Azure Resource Manager) Tools: [download link](https://marketplace.visualstudio.com/items?itemName=msazurermtools.azurerm-vscode-tools) | `code --install-extension msazurermtools.azurerm-vscode-tools`
* Install Azure Storage Explorer: [download link](https://azure.microsoft.com/en-in/features/storage-explorer/)
* Install Azure Functions Core Tools: [instructions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=linux%2Ccsharp%2Cbash#v2)

Note: After each lab, please ensure that you delete the created resources (so as to not accrue costs).
