using Newtonsoft.Json.Linq;
using RestSharp;

namespace CheckoutPaymentGateway.Client.Helpers
{
    /// <summary>
    /// A class to help the authentication process with Auth0
    /// </summary>
    public class AuthenticationHelper
    {
        /// <summary>
        /// Gets the access token using the configured client Id and Secret.
        /// </summary>
        /// <returns>The Access Token</returns>
        public static string GetAccessToken()
        {
            var client = new RestClient(Startup.StaticConfig["Auth0:AuthenticationUrl"]);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", $"{{\"client_id\":\"{Startup.StaticConfig["Auth0:ClientId"]}\",\"client_secret\":\"{Startup.StaticConfig["Auth0:ClientSecret"]}\",\"audience\":\"{Startup.StaticConfig["Auth0:Audience"]}\",\"grant_type\":\"client_credentials\"}}", ParameterType.RequestBody);
            var response = client.Execute(request);
            var jObject = JObject.Parse(response.Content);
            return jObject["access_token"].ToString();
        }
    }
}