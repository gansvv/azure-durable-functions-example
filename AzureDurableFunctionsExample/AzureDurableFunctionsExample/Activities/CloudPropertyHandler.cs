namespace Microsoft.AzureIoT.IIoT
{
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.DurableTask;
    using Microsoft.Extensions.Logging;

    public static class CloudPropertyHandler
    {
        [FunctionName("SetupCloudProperties")]
        public static async Task<double> ActivitySetupCloudProperties([ActivityTrigger] string cloudProperty, ILogger log)
        {            
            log.LogInformation($"==> Cloud property setup: {cloudProperty}.");        
            return await Task.FromResult(5000);
        }
    }
}