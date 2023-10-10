namespace Garage
{
    public class Garage<T> : IGarage<T> where T : IVehicle
    {

        private T[] vehicles; // array for storing vehicles
        private bool[] slotOccupied; // array to track occupied slots
        public int Capacity { get; private set; }

        public Garage(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than zero.");
            }

            Capacity = capacity;
            vehicles = new T[capacity];
            slotOccupied = new bool[capacity]; // initializing slot traking array
        }

        public bool checkCapacity(int numVehiclesToPopulate)
        {
            int availableSlot = slotOccupied.Count(occupied => !occupied);
            if (availableSlot >= numVehiclesToPopulate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFull()
        {
            return slotOccupied.All(occupied => occupied);
        }
        public void AddVehicle(T vehicle)
        {
            if (IsFull())
            {
                Console.WriteLine("The garage is full, cannot add more vehicles.");
                return;
            }
            int index = Array.FindIndex(slotOccupied, occupied => !occupied);

            vehicles[index] = vehicle;
            slotOccupied[index] = true;
        }

        public void RemoveVehicle(string registrationNumber)
        {
            int index = -1;
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (slotOccupied[i] && vehicles[i] != null && vehicles[i].RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                Console.WriteLine($"Vehicle with registration number {vehicles[index].RegistrationNumber} removed from the garage.");
                vehicles[index] = default(T);
                slotOccupied[index] = false;
            }
            else
            {
                Console.WriteLine($"No vehicle with registration number {registrationNumber} found in the garage.");
            }
        }

        public void ListAllVehicles()
        {
            Console.WriteLine("Vehicles in the garage:");

            bool found = false;
            for (int i = 0; i < Capacity; i++)
            {
                if (slotOccupied[i] && vehicles[i] != null)
                {
                    found = true;
                    Console.WriteLine($"{vehicles[i].GetType().Name} - Registration Number: {vehicles[i].RegistrationNumber}");
                }
            }
            if (!found)
            {
                Console.WriteLine("The garage is empty. There are no vehicles.");
            }
        }


        public void SetCapacity(int newCapacity)
        {
            if (newCapacity <= 0)
            {
                Console.WriteLine("Capacity must be greater than zero.");
                return;
            }
            if (newCapacity < slotOccupied.Count(occupied => occupied))
            {
                Console.WriteLine("Cannot set capacity lower than the current number of vehicles.");
                return;
            }
            Capacity = newCapacity;
            Array.Resize(ref vehicles, Capacity);
            Array.Resize(ref slotOccupied, Capacity);
            Console.WriteLine($"Capacity is set to {Capacity}.");

        }

        public void PopulateGarage(IEnumerable<T> vehicleList)
        {
            foreach (var vehicle in vehicleList)
            {
                AddVehicle(vehicle);
            }
        }

        public T FindVehicleByRegistrationNumber(string registrationNumber)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null && vehicles[i].RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    return vehicles[i];
                }
            }
            return default(T); // Return default value if the vehicle is not found.
        }

        public IEnumerable<T> SearchVehicles(Func<T, bool> predicate)
        {
            return vehicles.Where((vehicle, i) => slotOccupied[i] && vehicle != null && predicate(vehicle));
        }


        public bool IsEmpty()
        {
            return slotOccupied.All(occupied => !occupied);
        }

        public bool IsVehicleInGarage(string registrationNumber)
        {
            return vehicles.Any(vehicle => vehicle != null && vehicle.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));
        }


        public void ClearGarage()
        {
            Array.Clear(vehicles, 0, Capacity);
            Array.Clear(slotOccupied, 0, Capacity);
            Console.WriteLine("All vehicles removed from the garage.");
        }

    }
}
