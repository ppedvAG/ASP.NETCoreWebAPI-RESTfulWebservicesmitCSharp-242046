using Newtonsoft.Json;

namespace M007_HttpClient
{
    internal class Program
    {
        const string API_URL = "https://localhost:7239/api/";

        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{API_URL}orders?customerid=ANTON");

                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var orders = JsonConvert.DeserializeObject<Order[]>(responseBody);

                    
                    
           
                    
                    Console.WriteLine(responseBody);
                    Console.ReadLine();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
        }
    }
}
