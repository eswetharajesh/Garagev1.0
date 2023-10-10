namespace Garage.Tests
{
    public class FindVehicleByRegistrationNumberTests
    {
        [Fact]
        public void FindVehicleByRegistrationNumber_PositiveTest()
        {
            // Arrange
            var garage = new Garage<IVehicle>(2);
            IVehicle car = new Car("ABC123", "Red", 4, "Sedan");
            garage.AddVehicle(car);

            // Act
            var foundVehicle = garage.FindVehicleByRegistrationNumber("ABC123");

            // Assert
            Assert.Equal(car, foundVehicle);
        }

        [Fact]
        public void FindVehicleByRegistrationNumber_NegativeTest_VehicleNotFound()
        {
            //Arrange
            var garage = new Garage<IVehicle>(2);
            IVehicle airplane = new Airplane("FLY007", "Pink", 5, 2);

            //Act
            var foundVehicle = garage.FindVehicleByRegistrationNumber("XYZ765");

            //Assert
            Assert.Null(foundVehicle);
        }
    }
}
