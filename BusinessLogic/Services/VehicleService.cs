using BusinessLogic.Contracts;
using BusinessLogic.Models;
using System.Drawing;

namespace BusinessLogic.Services
{
    public class VehicleService : IVehicleService
    {
        private static readonly string[] ModelNames =
        [
            "Model S", "Type R", "GT X", "Model Z", "Type Q",
            "Model Y", "Type N", "GT A", "Model K", "Type G",
            "Model M", "Type V", "GT E", "GT O", "GT S",
            "C-Class ", "X-Class ", "E-Series ", "S-Line ", "Z-Line "
        ];

        private static readonly int BrandCount = Enum.GetValues(typeof(VehicleBrand)).Length;
        private static readonly int ColorCount = Enum.GetValues(typeof(KnownColor)).Length;

        public Vehicle CreateVehicle(int id)
        {
            var brand = (VehicleBrand)Random.Shared.Next(0, BrandCount);
            var color = (KnownColor)Random.Shared.Next(27, ColorCount);
            var modelName = ModelNames[Random.Shared.Next(ModelNames.Length)];
            var topSpeed = Random.Shared.Next(10, 25) * 10;
            var car = new Vehicle
            {
                Id = id,
                Brand = brand,
                ModelName = modelName,
                Color = color,
                TopSpeed = topSpeed,
            };
            return car;
        }
    }
}
