using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json; 
using System.Linq;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Data.Repository;
using Data.MoverRepository.Models;

namespace FunctionDemo
{
    public class FunctionApi
    {

        private readonly dbDataContext dataContext;
        public FunctionApi(dbDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [FunctionName(nameof(UserAuthenication))]
        public async Task<IActionResult> UserAuthenication([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "auth")] User userCredentials, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            // TODO: Perform custom authentication here; we're just using a simple hard coded check for this example
            bool authenticated = userCredentials?.UserName.Equals("Admin", StringComparison.InvariantCultureIgnoreCase) ?? false;
            if (!authenticated)
            {
                return await Task.FromResult(new UnauthorizedResult()).ConfigureAwait(false);
            }
            else
            {
                GenerateJWTToken generateJWTToken = new();
                string token = generateJWTToken.IssuingJWT(userCredentials.UserName);
                return await Task.FromResult(new OkObjectResult(token)).ConfigureAwait(false);
            }
        }
        [FunctionName("demo")]
        public async Task<IActionResult> Get([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req, ILogger log)
        {
            log.LogInformation("Getting todo list items");
            // Check if we have authentication info.
            ValidateJWT auth = new ValidateJWT(req);
            if (!auth.IsValid)
            {
                return new UnauthorizedResult(); // No authentication info.
            }
            var rs = await dataContext.Users.ToListAsync();
            return new OkObjectResult(rs);
        }
        [FunctionName("demo2")]
        public async Task<IActionResult> Get2([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req, ILogger log)
        {
            log.LogInformation("Getting todo list items");
            // Check if we have authentication info.
            ValidateJWT auth = new ValidateJWT(req);
            if (!auth.IsValid)
            {
                return new UnauthorizedResult(); // No authentication info.
            }
            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;


            var rs = await dataContext.Users.Where(m => m.FirstName.Contains(name)).ToListAsync();
            return new OkObjectResult(rs);
        }
    }
}
