using BusinessLogic;
using BusinessLogic.Contracts;
using BusinessLogic.Models;
using Moq;

namespace M010_UnitTests
{
    [TestClass]
    public class VehicleTest
    {
        Mock<IVehicleService> _mockVehicleService = new Mock<IVehicleService>();

        [TestInitialize]
        public void TestInitialize(TestContext context)
        {
            _mockVehicleService
                .Setup(m => m.CreateVehicle(It.IsAny<int>()))
                .Returns<int>((id) => new Vehicle { Id = id });
        }

        [TestMethod]
        [DataRow(5)]
        public void TestCreateVehicle(int expectedId)
        {
            // Arrange
            var service = _mockVehicleService.Object;

            // Act
            var vehicles = service.CreateVehicle(expectedId);

            // Assert
            Assert.AreEqual(expectedId, vehicles.Id, "Expected that there are any vehicles");
        }
    }
}