using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Challenge1
{
    public static class Function1
    {
        [FunctionName("SpinTheDreidel")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            Random random = new Random();
            int result = random.Next(0, 4);
            DreidelSides side;
            Enum.TryParse<DreidelSides>(result.ToString(), out side);
            return (ActionResult) new OkObjectResult($"{side.ToString()}");
        }

        public enum DreidelSides
        {
            נ,//(Nun),
            ג,//(Gimmel),
            ה,//(Hay), or
            ש //(Shin)
        }
    }
}
