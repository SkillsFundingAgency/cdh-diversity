using System;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace NCS.DSS.Diversity.DeleteDiversityHttpTrigger
{
    public static class DeleteDiversityHttpTrigger
    {
        [Disable]
        [FunctionName("Delete")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "Customers/{customerId}/DiversityDetails/{diversityId}")]HttpRequestMessage req, TraceWriter log, string diversityId)
        {
            log.Info("C# HTTP trigger function processed a request.");
            
            if (!Guid.TryParse(diversityId, out var diversityGuid))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(diversityId),
                        System.Text.Encoding.UTF8, "application/json")
                };
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(diversityGuid),
                    System.Text.Encoding.UTF8, "application/json")
            };
        }
    }
}
