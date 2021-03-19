namespace Microsoft.AzureIoT.IIoT
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.DurableTask;
    using Microsoft.Extensions.Logging;

    public static class AssetInstanceHandler
    {
        [FunctionName("CreateAssetInstance")]
        public static async Task<double> CreateAssetInstance([ActivityTrigger] AssetInfo assetInfo, ILogger log)
        {
            await Task.Delay(10000);
            log.LogInformation($"==> Asset created {assetInfo.assetName} with relationship {assetInfo.assetRelationshipName}.");
            return await Task.FromResult(10000);
        }
    }
}



