using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public interface IGarage<T> where T : IVehicle
    {
        int Capacity { get; }
        void AddVehicle(T vehicle);
        void RemoveVehicle(string registrationNumber);
        void ListAllVehicles();
        void SetCapacity(int newCapacity);
        void PopulateGarage(IEnumerable<T> vehicleList);
        T FindVehicleByRegistrationNumber(string registrationNumber);
        IEnumerable<T> SearchVehicles(Func<T, bool> predicate);
        bool IsEmpty();
        bool IsVehicleInGarage(string registrationNumber);
        void ClearGarage();

    }
}
