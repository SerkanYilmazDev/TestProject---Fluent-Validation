using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;

namespace TestProject.Console
{
    class Program
    {
        private static string _keycloakServerUrl = "";
        private static string _keycloakRealmName = "";
        private static string _keycloakGrantType = "";
        private static string _keycloakClientId = "";
        private static string _keycloakClientSecret = "";

        static void Main(string[] args)
        {
            #region Classic
            //var students = Get("https://localhost:44381/api/student");
            #endregion

            #region RestSharp Demo1
            //var client = new RestClient("https://localhost:44381");

            //var request = new RestRequest("/api/student", DataFormat.Json);

            //var response = client.Get(request);
            #endregion

            #region RestSharp Demo2

            //var keycloakToken = GetToken();

            #endregion

            #region Flurl
            var resultOfFlurl = Task.Run(() => GetWithFlurl());

            var result = resultOfFlurl.GetAwaiter().GetResult();
            #endregion
        }


        public static string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static string GetToken()
        {
            var jsonDeserializer = new JsonDeserializer();

            var url = $"{_keycloakServerUrl}/auth/realms/{_keycloakRealmName}/protocol/openid-connect/token";
            var data =
                $"grant_type={_keycloakGrantType}&client_id={_keycloakClientId}&client_secret={_keycloakClientSecret}";

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("raw", data, ParameterType.RequestBody);

            var response = client.Execute(request);

            var keycloakTokenResponse = jsonDeserializer.Deserialize<KeycloakToken>(response);

            return keycloakTokenResponse.access_token;
        }

        private static async Task<string> GetWithFlurl()
        {
            return await "https://localhost:44381"
                                                  .WithHeader("Accept", "application/json")
                                                  .AppendPathSegment("/api/student")
                                                  .GetStringAsync();

        }
    }
}
