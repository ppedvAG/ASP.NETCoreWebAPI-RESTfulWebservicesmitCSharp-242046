using System.Drawing;

namespace M007_HttpClient.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public VehicleBrand Brand { get; set; }

        public string ModelName { get; set; }

        public int TopSpeed { get; set; }

        public KnownColor Color { get; set; }
    }

    public enum VehicleBrand
    {
        Mercedes,
        BMW,
        Toyota,
        Opel,
        Skoda,
        Volvo
    }
}
