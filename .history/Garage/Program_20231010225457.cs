// See https://aka.ms/new-console-template for more information

using Garage;

public class Program
{
    static void Main(string[] args)
    {
        IUI consoleUI = new ConsoleUI();
        GarageHandler garageHandler = InitializeGarage(consoleUI);
        GarageInteraction garageInteraction = new GarageInteraction(consoleUI, garageHandler);

        while (true)
        {
            ShowMainMenu(consoleUI);

            string choice = consoleUI.GetInput("\nEnter your choice: ");
            switch (choice)
            {
                case "1":
                    garageInteraction.ListAllVehicles();
                    break;
                case "2":
                    garageInteraction.AddVehicleToGarage();
                    break;
                case "3":
                    garageInteraction.RemoveVehicleFromGarage();
                    break;
                case "4":
                    garageInteraction.SetGarageCapacity();
                    break;
                case "5":
                    garageInteraction.PopulateGarage();
                    break;
                case "6":
                    garageInteraction.FindVehicleByRegistrationNumber();
                    break;
                case "7":
                    garageInteraction.SearchVehicles();
                    break;
                case "8":
                    ExitApplication(consoleUI);
                    return;
                default:
                    consoleUI.DisplayOutput("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    private static GarageHandler InitializeGarage(IUI ui)
    {
        int capacity;
        while (true)
        {
            string input = ui.GetInput("\nEnter the garage capacity: ");
            if (int.TryParse(input, out capacity) && capacity > 0)
            {
                return new GarageHandler(capacity);
            }
            else
            {
                ui.DisplayOutput("\nInvalid capacity. Please enter a valid positive value");
            }
        }
    }
    private static void ShowMainMenu(IUI ui)
    {
        ui.DisplayOutput("\nGarage Application Menu: ");
        ui.DisplayOutput("\n1. List all parked vehicles.");
        ui.DisplayOutput("\n2. Add a vehicle.");
        ui.DisplayOutput("\n3. Remove a vehicle.");
        ui.DisplayOutput("\n4. Set capacity.");
        ui.DisplayOutput("\n5. Populate the garage with vehicles.");
        ui.DisplayOutput("\n6. Find a vehicle by registration number.");
        ui.DisplayOutput("\n7. Search a vehicle by characteristics.");
        ui.DisplayOutput("\n8. Exit.");
    }
    private static void ExitApplication(IUI ui)
    {
        ui.DisplayOutput("\nExiting the Garage Application. Tack!");
    }
}
