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
            return garage.CheckCapacity(numVehiclesToPopulate);
        }

        public void AddVehicleToGarage(IVehicle vehicle)
        {
            garage.AddVehicle(vehicle);
        }

        public bool RemoveVehicleFromGarage(string registrationNumber)
        {
            var found = FindVehicleByRegistrationNumber(registrationNumber);

            if (found != null)
            {
                return garage.RemoveVehicle(found);
            }

            return false;
        }

        public IEnumerable<string> ListAllVehiclesInGarage()
        {

            var res = garage.Any(vehicle =>  vehicle.RegistrationNumber.Equals("ABC123", StringComparison.OrdinalIgnoreCase));

            var res =  garage.Select(v => v.ToString());

            var r = new List<string>();

            foreach (var item in garage)
            {
                r.Add(item.ToString());
            }

            var redVehiclesRegNo = garage.Where(v => v.Color == "Red")
                                         .Select(r => r.RegistrationNumber);

            List<string> found = new();
            foreach(var v in garage)
            {
                if(v.Color == "Red")
                {
                    found.Add(v.RegistrationNumber);
                }
            }


            foreach (var vehicle in garage)
            {
                Console.WriteLine(vehicle);
            }

            var str = "sdvfsgdghdfhhf";

            var res = str.Where(c => c.Equals('s'));

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            // garage.ListAllVehicles();
        }

        public void SetGarageCapacity(int newCapacity)
        {
            garage.SetCapacity(newCapacity);
        }

        public void PopulateGarage(IEnumerable<IVehicle> vehicleList)
        {
            garage.PopulateGarage(vehicleList);
        }

        public IVehicle? FindVehicleByRegistrationNumber(string registrationNumber)
        {
            return garage.FirstOrDefault(v => v.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));
           // return garage.FindVehicleByRegistrationNumber(registrationNumber);
        }

        public IEnumerable<IVehicle> SearchVehiclesInGarage(Func<IVehicle, bool> predicate)
        {
            return garage.SearchVehicles(predicate);
        } 
        
        public IEnumerable<IVehicle> SearchVehiclesInGarage(SearchParameters search)
        {

            IEnumerable<IVehicle> result = search.VehicleType == "All"
                ? garage
                : garage.Where(v => v.VehicleType == search.VehicleType);

            if (!string.IsNullOrEmpty(search.Color))
            {
                result = result.Where(v => v.Color ==  search.Color);
            }

            return result.ToList();
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

