using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using NCS.DSS.Diversity.Annotations;
using NCS.DSS.Diversity.Cosmos.Helper;
using NCS.DSS.Diversity.PostDiversityHttpTrigger.Service;
using NCS.DSS.Diversity.Validation;
using Newtonsoft.Json;

namespace NCS.DSS.Diversity.PostDiversityHttpTrigger.Function
{
    public static class PostDiversityHttpTrigger
    {
        [FunctionName("Post")]
        [ResponseType(typeof(Models.Diversity))]
        [Response(HttpStatusCode = (int)HttpStatusCode.Created, Description = "Diversity Created", ShowSchema = true)]
        [Response(HttpStatusCode = (int)HttpStatusCode.NoContent, Description = "Diversity does not exist", ShowSchema = false)]
        [Response(HttpStatusCode = (int)HttpStatusCode.BadRequest, Description = "Request was malformed", ShowSchema = false)]
        [Response(HttpStatusCode = (int)HttpStatusCode.Unauthorized, Description = "API key is unknown or invalid", ShowSchema = false)]
        [Response(HttpStatusCode = (int)HttpStatusCode.Forbidden, Description = "Insufficient access", ShowSchema = false)]
        [Response(HttpStatusCode = 422, Description = "Diversity validation error(s)", ShowSchema = false)]
        [Display(Name = "Post", Description = "Ability to create a new diversity record for a given customer.")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Customers/{customerId}/DiversityDetails")]HttpRequestMessage req, TraceWriter log, string customerId)
        {
            log.Info("C# HTTP trigger function processed a request.");

            if (!Guid.TryParse(customerId, out var customerGuid))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(customerGuid),
                        System.Text.Encoding.UTF8, "application/json")
                };
            }

            // Get request body
            var diversity = await req.Content.ReadAsAsync<Models.Diversity>();

            // validate the request
            var validate = new Validate();
            var errors = validate.ValidateResource(diversity);

            if (errors != null && errors.Any())
            {
                return new HttpResponseMessage((HttpStatusCode)422)
                {
                    Content = new StringContent("Validation error(s) : " +
                                                JsonConvert.SerializeObject(errors),
                        System.Text.Encoding.UTF8, "application/json")
                };
            }

            var resourceHelper = new ResourceHelper();
            var doesCustomerExist = resourceHelper.DoesCustomerExist(customerGuid);

            if (!doesCustomerExist)
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent)
                {
                    Content = new StringContent("Unable to find a customer with Id of : " +
                                                JsonConvert.SerializeObject(customerGuid),
                        System.Text.Encoding.UTF8, "application/json")
                };
            }

            var diversityService = new PostDiversityHttpTriggerService();
            var diversityId = await diversityService.CreateAsync(diversity);

            return diversityId == null
                ? new HttpResponseMessage(HttpStatusCode.BadRequest)
                : new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent("Created Diversity record with Id of : " + diversityId)
                };
        }
    }
}