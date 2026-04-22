using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace HTTPAPI
{
    public class Faker
    {
        private static readonly string BASE_URL = "https://fakerapi.it/api/v2/books";

        public static async Task <BooksResponse?> GetBooksAsync(int amount)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                string url = $"{BASE_URL}?_quantity={amount}";

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    //Console.WriteLine("Our response is: " + response);

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine("Our response body is: " + responseBody);
                    if (!string.IsNullOrEmpty(responseBody))
                    {
                        var list = JsonSerializer.Deserialize<BooksResponse>(responseBody);
                        return list;
                    }
                    else
                    {
                        return null;
                    }
                    
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("Our exception: " + ex);
                    return null;
                }

            }
        }
    }
}
