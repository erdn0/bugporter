using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static Bugporter.API.Startup;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Bugporter.API.Features.ReportBug;
using Bugporter.API.Features.ReportBug.GitHub;

[assembly: FunctionsStartup(typeof(Bugporter.API.Startup))]

namespace Bugporter.API
{
    public class ReportBugFunction
    {
        private readonly ILogger<ReportBugFunction> _logger;
        private readonly CreateGitHubIssueCommand _createGitHubIssueCommand;
        public ReportBugFunction(ILogger<ReportBugFunction> logger, CreateGitHubIssueCommand createGitHubIssueCommand)
        {
            _createGitHubIssueCommand = createGitHubIssueCommand;
            _logger = logger;
        }

        [FunctionName("ReportBugFunction")]
        public async Task<IActionResult> 
            Run([HttpTrigger(AuthorizationLevel.Anonymous,"post", Route = "bugs")] HttpRequest req)
        {
            NewBug newBug = new NewBug("Very bad bug", "The graphic is not centered");

            ReportedBug reportedBug = await _createGitHubIssueCommand.Execute(newBug);

            return new OkObjectResult(reportedBug);
        }
    }
}
