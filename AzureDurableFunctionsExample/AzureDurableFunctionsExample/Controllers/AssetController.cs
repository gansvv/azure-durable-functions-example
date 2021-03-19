namespace Microsoft.AzureIoT.IIoT
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.DurableTask;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;

    public static class AssetController
    {     
        [FunctionName("TriggerCreateAsset")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            var assetInfo = await req.Content.ReadAsAsync<AssetInfo>();

            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("CreateAsset", assetInfo);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);           
        }
    }
}
