using Newtonsoft.Json.Linq;
using RestSharp;

namespace CheckoutPaymentGateway.Client.Helpers
{
    public class AuthenticationHelper
    {
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