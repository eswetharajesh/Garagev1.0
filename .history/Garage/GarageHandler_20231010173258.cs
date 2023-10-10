namespace Garage
{
    public class GarageHandler
    {
        private IGarage<IVehicle> garage; //Instantiate the garage 
        private IVehicle[] vehicles;

        public GarageHandler(int capacity)
        {
            //Initialize the garage with the specified capacity
            garage = new Garage<IVehicle>(capacity);
            vehicles = new IVehicle[capacity];
        }

        public void AddVehicleToGarage(IVehicle vehicle)
        {
            garage.AddVehicle(vehicle);
            // Add the vehicle to the array as well
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    break;
                }
            }
        }

        public void RemoveVehicleFromGarage(string registrationNumber)
        {
            garage.RemoveVehicle(registrationNumber);
        }

        public IVehicle[] ListAllVehiclesInGarage()
        {
            // Return the array of vehicles
            return vehicles;
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

