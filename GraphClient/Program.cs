using Microsoft.Azure.Management.ResourceGraph;
using Microsoft.Azure.Management.ResourceGraph.Models;
using System;
using System.Collections.Generic;

namespace GraphClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string clientId = "[clientid]";
            string clientSecret = "[clientSecret]";
            string tenantId = "[tenantId]";
            string subscriptionId = "[subscriptionId]";
            string query = "Resources | project name, type | limit 5";
            string authority = $"https://login.microsoftonline.com/{tenantId}";

            ResourceGraphClient client = new ResourceGraphClient(AuthenticationHelper.GetServiceClientCredentials("https://management.core.windows.net", clientId, clientSecret, authority).Result);

            var response = client.Resources(new QueryRequest(new List<string>(){ subscriptionId }, query));

            Console.WriteLine(response);
        }
    }
}
