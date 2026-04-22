
namespace HTTPAPI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            BooksResponse? response = await Faker.GetBooksAsync();
            foreach (var d in response.Data)
            {
                if (d != null)
                {
                    Console.WriteLine("The author is: " + d.Author);
                }
            }
        }
    }
}
