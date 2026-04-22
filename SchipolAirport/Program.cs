
namespace SchipolAirport
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            SchipolDestinationResponse? response = await SchipolAPI.GetDestinations(Utils.ID, Utils.Key);

            foreach (var d in response.Destination)
            {
                if (d != null)
                {
                    Console.WriteLine("destination: " + d.Country);
                }
            }
        }
    }
}