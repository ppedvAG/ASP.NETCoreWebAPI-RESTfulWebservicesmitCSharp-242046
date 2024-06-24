using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Drawing;

namespace BusinessLogic.Models
{
    [PrimaryKey("Id")]
    [DebuggerDisplay("Id: {Id}, Brand: {Brand}, Model: {ModelName}")]
    public class Vehicle
    {
        [Column("VehicleId")]
        public int Id { get; set; }

        [Column("VehicleBrand"), Required]
        public VehicleBrand Brand { get; set; }

        [Required]
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
