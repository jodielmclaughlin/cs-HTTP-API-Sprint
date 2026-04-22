using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HTTPAPI
{
    public class BooksResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = "OK";

        [JsonPropertyName("data")]
        public List<Data> Data { get; set; } = new List<Data>();
    }
}
