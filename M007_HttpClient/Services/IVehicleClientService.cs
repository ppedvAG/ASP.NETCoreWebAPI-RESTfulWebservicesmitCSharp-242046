
namespace M007_HttpClient.Services
{
    public interface IVehicleClientService
    {
        Task GenerateVehicles(int count);

        Task<IEnumerable<Models.Vehicle>> FetchVehicles();
    }
}