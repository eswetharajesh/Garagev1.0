using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Garage
{
    public abstract class Vehicle : IVehicle

    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public string VehicleType { get; set; }

        protected Vehicle(string registrationNumber, string color, int numberOfWheels, string vehicletype)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
            VehicleType = vehicletype;
        }
        
    }

    public class Airplane : Vehicle
    {
        public int NumberOfengines { get; set; }
        public Airplane(string registrationNumber, string color, int numberOfWheels, int numberOfEngines) : base(registrationNumber, color, numberOfWheels, "Airplane")
        {
            NumberOfengines = numberOfEngines;
        }

    }

    public class Motorcycle : Vehicle
    {
        public string MotorcycleType { get; set; }

        public Motorcycle(string registrationNumber, string color, int numberOfWheels, string motorcycleType)
            : base(registrationNumber, color, numberOfWheels, "Motorcycle")
        {
            MotorcycleType = motorcycleType;
        }
    }

    public class Car : Vehicle
    {
        public string CarType { get; set; }

        public Car(string registrationNumber, string color, int numberOfWheels, string carType)
            : base(registrationNumber, color, numberOfWheels, "Car")
        {
            CarType = carType;
        }
    }

    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }
        public Bus(string registrationNumber, string color, int numberOfWheels, int numberOfSeats) : base(registrationNumber, color, numberOfWheels,"Bus")
        {
            NumberOfSeats = numberOfSeats;
        }
    }

    public class Boat : Vehicle
    {
        public double Length { get; set; }
        public Boat(string registrationNumber, string color, int numberOfWheels, double length) : base(registrationNumber, color, numberOfWheels,"Boat")
        {
            Length = length;
        }
    }


}
