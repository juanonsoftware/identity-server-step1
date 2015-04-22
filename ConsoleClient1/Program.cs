using System;
using System.Net.Http;
using Thinktecture.IdentityModel.Client;

namespace ConsoleClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            var response = GetToken();
            Console.WriteLine("AccessToken: " + response.AccessToken);
            CallApi(response);

            var response2 = GetUserToken();
            Console.WriteLine("AccessToken: " + response2.AccessToken);
            CallApi(response2);

            Console.ReadLine();
        }

        static TokenResponse GetToken()
        {
            var client = new OAuth2Client(
                new Uri("http://localhost:44333/connect/token"),
                "silicon",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

            return client.RequestClientCredentialsAsync("api1").Result;
        }

        static TokenResponse GetUserToken()
        {
            var client = new OAuth2Client(
                new Uri("http://localhost:44333/connect/token"),
                "carbon",
                "21B5F798-BE55-42BC-8AA8-0025B903DC3B");

            return client.RequestResourceOwnerPasswordAsync("bob", "secret", "api1").Result;
        }

        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            Console.WriteLine(client.GetStringAsync("http://localhost:34156/api/test").Result);
        }
    }
}
