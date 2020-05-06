using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Vemic.Trackall.Function.Core.Idm
{
    public static class EntryFunction
    {
        [FunctionName("function/core/idm/entry")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            out object document,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // getbody.
            string userid = req.Query["userid"];
            string name = req.Query["name"];
            string task = req.Query["task"];
            string duedate = req.Query["duedate"];

            // validate.
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(task))
            {
                document = null;
                return new BadRequestResult();
            }

            document = new
            {
                name,
                duedate,
                task
            };

            return new OkObjectResult(document);
        }
    }
}