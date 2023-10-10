namespace Garage.Tests
{
    public class AddVehicleTest
    {
        [Fact]
        public void AddVehicle_PositiveTest()
        {
            // Arrange
            var garage = new Garage<IVehicle>(2);
            IVehicle car = new Car("ABC123", "Red", 4, "Sedan");

            // Act
            garage.AddVehicle(car);

            // Assert
            Assert.True(garage.IsVehicleInGarage("ABC123"));
        }

        [Fact]
        public void AddVehicle_NegativeTest_GarageIsFull()
        {
            // Arrange
            var garage = new Garage<IVehicle>(1);
            IVehicle car1 = new Car("ABC123", "Red", 4, "Sedan");
            IVehicle car2 = new Car("XYZ789", "Blue", 4, "Sedan");

            // Act
            garage.AddVehicle(car1);
            garage.AddVehicle(car2);

            // Assert
            Assert.False(garage.IsVehicleInGarage("XYZ789"));
        }
    }
}
    
