namespace Garage.Tests
{
    public class RemoveVehicleTests
    {
        [Fact]
        public void RemoveVehicle_PositiveTest()
        {
            //Arrange
            var garage = new Garage<IVehicle>(2);
            IVehicle bus = new Bus("ABC123", "White", 4, 20);
            garage.AddVehicle(bus);

            //Act
            garage.RemoveVehicle("ABC123");

            //Assert
            Assert.False(garage.IsVehicleInGarage("ABC123"));
        }

        [Fact]
        public void RemoveVehicle_NegativeTest() 
        {
            var garage = new Garage<IVehicle>(2);
            IVehicle car = new Car("SwE23", "White", 4, "SUV");

            //Act
            garage.AddVehicle(car);
            garage.RemoveVehicle("XYZ78");

            //Assert
            Assert.False(garage.IsVehicleInGarage("XYZ78"));

        }
    }
}
