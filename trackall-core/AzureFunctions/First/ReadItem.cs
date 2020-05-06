using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Vemic.Trackall.AzureFunctions.First
{
    public static class ReadItem
    {

        [FunctionName("ReadItem2")]
        public static IActionResult Run2(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            // out object taskDocument,
            // object taskDocument,
            ILogger log)
        {
            string name = req.Query["name"];
            string task = req.Query["task"];
            string duedate = req.Query["duedate"];

            object taskDocument;

            // We need both name and task parameters.
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(task))
            {
                taskDocument = new
                {
                    name,
                    duedate,
                    task
                };

                return new OkObjectResult(taskDocument);
            }
            else
            {
                taskDocument = null;
                return new BadRequestResult();
            }
        }

        [FunctionName("ReadItem1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
