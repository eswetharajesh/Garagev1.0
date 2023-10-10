using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class GarageInteraction
    {
        private IUI ui;
        private GarageHandler garageHandler;

        public GarageInteraction(IUI ui, GarageHandler garageHandler)
        {
            this.ui = ui;
            this.garageHandler = garageHandler;
        }

        private string GenerateRandomColor() //used by populate method
        {
            string[] colors = { "Red", "Green", "Blue", "Yellow", "Black", "White" };
            Random random = new Random();
            return colors[random.Next(colors.Length)];
        }

        public void AddVehicleToGarage()
        {
            string registrationNumber = ui.GetInput("Enter the registration number of the vehicle:");

            if (garageHandler.FindVehicleByRegistrationNumber(registrationNumber) != null)
            {
                ui.DisplayOutput($"A vehicle with registration number {registrationNumber} is already registered.");
                return;
            }

            string color = ui.GetInput("Enter the color of the vehicle:");
            int numberOfWheels = GetValidPositiveIntInput("Enter the number of wheels:");

            string vehicleType = ui.GetInput("Enter the vehicle type (Car, Motorcycle, Bus, Boat, Airplane):");
            IVehicle newVehicle = CreateVehicle(vehicleType, registrationNumber, color, numberOfWheels);

            if (newVehicle != null)
            {
                garageHandler.AddVehicleToGarage(newVehicle);
                ui.DisplayOutput($"Vehicle with registration number {registrationNumber} added to the garage.");
            }
            else
            {
                ui.DisplayOutput($"Invalid vehicle type: {vehicleType}");
            }
        }

        private int GetValidPositiveIntInput(string message)
        {
            int value;
            while (true)
            {
                string input = ui.GetInput(message);
                if (int.TryParse(input, out value) && value > 0)
                {
                    return value;
                }
                else
                {
                    ui.DisplayOutput("Invalid input. Please enter a positive integer greater than o.");
                }
            }
        }

        private IVehicle CreateVehicle(string vehicleType, string registrationNumber, string color, int numberOfWheels)
        {
            switch (vehicleType.ToLower())
            {
                case "car":
                    string carType = ui.GetInput("Enter the car type:");
                    return new Car(registrationNumber, color, numberOfWheels, carType);

                case "motorcycle":
                    string motorcycleType = ui.GetInput("Enter the motorcycle type:");
                    return new Motorcycle(registrationNumber, color, numberOfWheels, motorcycleType);

                case "airplane":
                    int numberOfEngines = GetValidPositiveIntInput("Enter the number of engines:");
                    return new Airplane(registrationNumber, color, numberOfWheels, numberOfEngines);

                case "bus":
                    int numberOfSeats = GetValidPositiveIntInput("Enter the number of seats:");
                    return new Bus(registrationNumber, color, numberOfWheels, numberOfSeats);

                case "boat":
                    double length = GetValidPositiveDoubleInput("Enter the length of the boat:");
                    return new Boat(registrationNumber, color, numberOfWheels, length);

                default:
                    return null;
            }
        }

        private double GetValidPositiveDoubleInput(string message)
        {
            double value;
            while (true)
            {
                string input = ui.GetInput(message);
                if (double.TryParse(input, out value) && value > 0)
                {
                    return value;
                }
                else
                {
                    ui.DisplayOutput("Invalid input. Please enter a positive number.");
                }
            }
        }


        public void RemoveVehicleFromGarage()
        {
            string registrationNumber = ui.GetInput("Enter the registration number of the vehicle to be removed: ");
            bool vehicleExists = garageHandler.IsVehicleInGarage(registrationNumber);
            if (!vehicleExists)
            {
                ui.DisplayOutput($"No vehicle with registration number {registrationNumber} found in garage.");
                return;
            }
            garageHandler.RemoveVehicleFromGarage(registrationNumber);
            ui.DisplayOutput($"Vehicle with registration number {registrationNumber} is removed from garage.");
        }

        public void ListAllVehicles()
        {
            ui.DisplayOutput("List of all vehicles in the garage:");

            garageHandler.ListAllVehiclesInGarage();

        }


        public void SetGarageCapacity()
        {
            string input = ui.GetInput("Enter the new garage capacity: ");
            if (int.TryParse(input, out int newCapacity) && newCapacity > 0)
            {
                garageHandler.SetGarageCapacity(newCapacity);
                ui.DisplayOutput($"Garage capacity is set to {newCapacity}");
            }
            else
            {
                ui.DisplayOutput("Invalid capacity. Please enter a positive value.");
            }
        }

        public void PopulateGarage()
        {
            int numVehiclesToPopulate;
            while (true)
            {
                string input = ui.GetInput("Enter number of vehicles to populate the garage: ");
                if (int.TryParse(input, out numVehiclesToPopulate) && numVehiclesToPopulate > 0)
                {
                    break;
                }
                else
                {
                    ui.DisplayOutput("Invalid Input. Please enter a non-negative value.");
                }
            }

            if (!garageHandler.CheckGarageCapacity(numVehiclesToPopulate))
            {
                ui.DisplayOutput("Cannot populate vehicle in garage due to unavailability of slot!");
                return;
            }

            Random random = new Random();
            for (int i = 0; i < numVehiclesToPopulate; i++)
            {
                string registrationNumber = $"ABC{random.Next(1, 9999)}";
                string color = GenerateRandomColor();
                int numberOfWheels = random.Next(2, 6);
                int vehicleType = random.Next(1, 6);

                IVehicle newVehicle;

                switch (vehicleType)
                {
                    case 1:
                        newVehicle = new Car(registrationNumber, color, numberOfWheels, "Sedan");
                        break;
                    case 2:
                        newVehicle = new Motorcycle(registrationNumber, color, numberOfWheels, "Sports");
                        break;
                    case 3:
                        newVehicle = new Airplane(registrationNumber, color, numberOfWheels, random.Next(1, 5));
                        break;
                    case 4:
                        newVehicle = new Bus(registrationNumber, color, numberOfWheels, random.Next(10, 51));
                        break;
                    case 5:
                        newVehicle = new Boat(registrationNumber, color, numberOfWheels, random.NextDouble() * 30);
                        break;
                    default:
                        newVehicle = null;
                        break;
                }
                if (newVehicle != null)
                {
                    garageHandler.AddVehicleToGarage(newVehicle);
                }
            }
            //ui.DisplayOutput($"Garage populated with {numVehiclesToPopulate} vehicles.");
        }

        public void FindVehicleByRegistrationNumber()
        {
            string registrationNumber = ui.GetInput("Enter the registration number of vehicle to find: ");
            IVehicle foundVehicle = garageHandler.FindVehicleByRegistrationNumber(registrationNumber);
            if (foundVehicle != null)
            {
                ui.DisplayOutput($"Vehicle found : {foundVehicle.GetType().Name} - Registration Number: {foundVehicle.RegistrationNumber}.");
            }
            else
            {
                ui.DisplayOutput($"No vehicle with registartion number {registrationNumber} was found in garage.");
            }
        }

        public void SearchVehicles()
        {
            string colorToSearch = ui.GetInput("Enter the color to search: ").ToLower();
            int wheelsToSearch;

            while (true)
            {
                string wheelsInput = ui.GetInput("Enter number of wheels to search: ");
                if (int.TryParse(wheelsInput, out wheelsToSearch) && wheelsToSearch >= 0)
                {
                    break;
                }
                else
                {
                    ui.DisplayOutput("Invalid input. Please enter a non-negative value.");
                }
            }

            var searchResults = garageHandler.SearchVehiclesInGarage(vehicle =>
                string.Equals(vehicle.Color.ToLower(), colorToSearch) &&
                vehicle.NumberOfWheels == wheelsToSearch);

            if (searchResults.Any())
            {
                ui.DisplayOutput("Vehicle search results:");
                foreach (var result in searchResults)
                {
                    ui.DisplayOutput($"{result.GetType().Name} - Registration Number: {result.RegistrationNumber}");
                }
            }
            else
            {
                ui.DisplayOutput("No matching vehicle found.");
            }
        }


    }
}
