using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchipolAirport
{
    public class Destination
    {
        [JsonPropertyName("country")]
        public string Country { get; set; } = "";
    }
}
