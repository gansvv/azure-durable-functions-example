namespace Microsoft.AzureIoT.IIoT
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.DurableTask;
    using Microsoft.Extensions.Logging;

    public static class CreateAssetOrchestrator
    {
        [FunctionName("CreateAsset")]
        public static async Task<double> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context,
            ILogger log)
        {
            // Receive Input
            var assetInfo = context.GetInput<AssetInfo>();
            List<double> assetTasks = new List<double>();

            // Call Activity Functions in parallel
            var createAsset = context.CallActivityAsync<double>("CreateAssetInstance", assetInfo);
            var addCloudProperty = context.CallActivityAsync<double>("SetupCloudProperties", assetInfo.cloudPropertyName);

            try
            {
                // Wait for Acitivity Functions to complete - Fan-In
                await Task.WhenAll(createAsset, addCloudProperty);
            }
            catch (System.Exception)
            {
                if (addCloudProperty.IsFaulted)
                {
                    log.LogError("Exception in bookng flight ticker. Please try later");
                    assetTasks.Add(createAsset.Result * 2);
                }
            }
            finally
            {
                assetTasks.Add(createAsset.Result);
                assetTasks.Add(addCloudProperty.Result);
            }

            // Call another Activity Function
            var retryOptions = new RetryOptions(
                firstRetryInterval: TimeSpan.FromSeconds(5),
                maxNumberOfAttempts: 5);

            return await context.CallActivityWithRetryAsync<double>("AddUpdateAssetOnEdge", retryOptions, assetTasks);

        }
    }
}