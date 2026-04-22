using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SchipolAirport
{
    public class SchipolAPI
    {
        private static readonly string BASE_URL = "https://api.schiphol.nl/public-flights";

        public static async Task<SchipolDestinationResponse?> GetDestinations (string id, string key)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{BASE_URL}/destinations";

                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("app_id", id);
                client.DefaultRequestHeaders.Add("app_key", key);
                client.DefaultRequestHeaders.Add("ResourceVersion", "v4");

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    //Console.WriteLine("our response: " + response);

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Console.WriteLine("our response body: " + responseBody);

                    if (!string.IsNullOrEmpty(responseBody))
                    {
                        var list = JsonSerializer.Deserialize<SchipolDestinationResponse>(responseBody);
                        return list;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Our exception: " + e);
                    return null;
                }
            }
        }
    }
}
