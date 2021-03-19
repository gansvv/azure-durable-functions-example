namespace Microsoft.AzureIoT.IIoT
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.DurableTask;
    using Microsoft.Extensions.Logging;

    public static class EdgeAssetHandler
    {
        [FunctionName("AddUpdateAssetOnEdge")]
        public static async Task<double> AddUpdateAssetOnEdge([ActivityTrigger] List<double> costs, ILogger log)
        {
            double totalCost = 0;        
            foreach (var cost in costs)
            {
                totalCost += cost;
            }
            log.LogInformation($"==> Adding Asset to Edge took {totalCost}.");

            return await Task.FromResult(totalCost);
        }
    }
}
