using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Devsulab.Common.Functions;

public static class AccountFunction
{
    [Function("AccountFunction")]
    public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("AccountFunction");
        logger.LogInformation("C# HTTP trigger function processed a request.");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        response.WriteString("Welcome to Azure Functions!");

        response.WriteString("Adding new Message: New version now! v.1.0.3.");
        
        response.WriteString("Adding new Message: New version now! v.1.0.4.");
        
        response.WriteString("Adding new Message: New version now! v.1.0.x.");

        return response;
        
    }
}