namespace Garage
{
    public class GarageHandler
    {
        private IGarage<IVehicle> garage; //Instantiate the garage 


        public GarageHandler(int capacity)
        {
            //Initialize the garage with the specified capacity
            garage = new Garage<IVehicle>(capacity);
        }

        public bool CheckGarageCapacity(int numVehiclesToPopulate)
        {
            return garage.checkCapacity(numVehiclesToPopulate);
        }

        public void AddVehicleToGarage(IVehicle vehicle)
        {
            garage.AddVehicle(vehicle);
        }

        public void RemoveVehicleFromGarage(string registrationNumber)
        {
            garage.RemoveVehicle(registrationNumber);
        }

        public void ListAllVehiclesInGarage()
        {
            garage.ListAllVehicles();
        }

        public void SetGarageCapacity(int newCapacity)
        {
            garage.SetCapacity(newCapacity);
        }

        public void PopulateGarage(IEnumerable<IVehicle> vehicleList)
        {
            garage.PopulateGarage(vehicleList);
        }

        public IVehicle FindVehicleByRegistrationNumber(string registrationNumber)
        {
            return garage.FindVehicleByRegistrationNumber(registrationNumber);
        }

        public IEnumerable<IVehicle> SearchVehiclesInGarage(Func<IVehicle, bool> predicate)
        {
            return garage.SearchVehicles(predicate);
        }

        public bool IsGarageEmpty()
        {
            return garage.IsEmpty();
        }

        public bool IsVehicleInGarage(string registrationNumber)
        {
            return garage.IsVehicleInGarage(registrationNumber);
        }

        public void ClearGarage()
        {
            garage.ClearGarage();
        }
    }
}

