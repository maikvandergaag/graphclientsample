using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using System.Threading.Tasks;

namespace GraphClient
{
    public static class AuthenticationHelper
    {
        public static async Task<ServiceClientCredentials> GetServiceClientCredentials(string resource, string clientId, string clientSecret, string authority)
        {
            AuthenticationContext authContext = new AuthenticationContext(authority);

            AuthenticationResult authResult = await authContext.AcquireTokenAsync(resource, new ClientCredential(clientId, clientSecret));

            string accessToken = authResult.AccessToken;

            ServiceClientCredentials serviceClientCreds = new TokenCredentials(authResult.AccessToken);

            return serviceClientCreds;
        }
    }
}
