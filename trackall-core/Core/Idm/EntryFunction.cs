using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Vemic.Trackall.AzureFunctions.Core.Idm
{
    public static class EntryFunction
    {
        [FunctionName("function/core/idm/entry")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB("Idm", "Items", Id = "id", ConnectionStringSetting = "MiappCosmosDBConnection")] out object idm,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if(req == null)
            {
                idm = null;
                return new BadRequestResult();
            }

            // getbody.
            IQueryCollection requery = req.Query;
            string userid = requery["userid"];
            string name = requery["name"];
            string task = requery["task"];
            string duedate = requery["duedate"];

            // validate.
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(task))
            {
                idm = null;
                return new BadRequestResult();
            }

            idm = new
            {
                name,
                duedate,
                task
            };

            return new OkObjectResult(idm);
        }
    }
}