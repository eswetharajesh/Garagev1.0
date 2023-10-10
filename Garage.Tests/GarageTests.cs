using System;
using Xunit;
using Garage;



namespace Garage.Tests
{
    public class GarageTests
    {
        [Fact]
        public void AddVehicle_GarageIsNotFull()
        {
            Garage<IVehicle> garage = new Garage<IVehicle>(5);
            IVehicle vehicle = new Car ("ABC123", "Black", 4, "Petrol");

            garage.AddVehicle(vehicle);

            Assert.True(garage.IsVehicleInGarage("ABC123"));
        }
    }
}
    
