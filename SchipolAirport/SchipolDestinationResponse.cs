using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchipolAirport
{
    public class SchipolDestinationResponse
    {
        [JsonPropertyName("destinations")]
        public List<Destination> Destination { get; set; } = new List<Destination>();
    }
}
