using BusinessLogic.Contracts;
using M003_VehicleFleetApi.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace M010_UnitTests
{
    [TestClass]
    public class VehicleFleetTest
    {
        [TestMethod]
        public void GetVehicles_ReturnsVehicles()
        {
            // Arrange
            var service = Mock.Of<IVehicleService>();
            var logger = Mock.Of<ILogger<VehiclesController>>();
            var controller = new VehiclesController(service, logger);

            // Act
            var result = controller.GetVehicles();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
        }
    }
}