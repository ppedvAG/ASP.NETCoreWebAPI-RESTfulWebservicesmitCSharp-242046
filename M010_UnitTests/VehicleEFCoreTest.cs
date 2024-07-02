using BusinessLogic;
using BusinessLogic.Contracts;
using BusinessLogic.Models;
using BusinessLogic.Services;
using M005_EFCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace M010_UnitTests
{
    [TestClass]
    public class VehicleEFCoreTest
    {
        // Database wird je Test immer neu erstellt um einheitlichen Ausgangszustand zu erhalten
        private readonly WebApiDbContext _context = new TestDatabase().CreateContext();

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Dispose();
        }

        [TestMethod]
        public async Task GetVehicles_ReturnsVehicles()
        {
            // Arrange
            var service = Mock.Of<IVehicleService>();
            var logger = Mock.Of<ILogger<VehiclesController>>();
            var controller = new VehiclesController(service, logger, _context);

            // Act
            var result = await controller.GetVehicles();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        [DataRow(5)]
        public async Task GenerateVehicles_ReturnsOk(int count)
        {
            // Arrange
            var service = new VehicleService();
            var logger = Mock.Of<ILogger<VehiclesController>>();
            var controller = new VehiclesController(service, logger, _context);

            // Act
            var result = await controller.GenerateVehicles(count);

            // Assert
            Assert.IsInstanceOfType<StatusCodeResult>(result);
            var statusCode = ((StatusCodeResult)result).StatusCode;
            Assert.AreEqual(200, statusCode);
        }
    }
}