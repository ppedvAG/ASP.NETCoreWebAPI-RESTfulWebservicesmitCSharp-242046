using M007_HttpClient.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace M007_HttpClient.Services
{
    public class VehicleClientService : IVehicleClientService
    {
        private readonly HttpClient _client;

        public VehicleClientService(HttpClient client)
        {
            _client = client;
        }

        public async Task GenerateVehicles(int count)
        {

        }

        public async Task<IEnumerable<Vehicle>> FetchVehicles()
        {
            var response = await _client.GetAsync("all");

            var content = await response.Content.ReadAsStringAsync();

            var vehicles = JsonConvert.DeserializeObject<IEnumerable<Vehicle>>(content);
            return vehicles ?? [];
        }
    }
}
