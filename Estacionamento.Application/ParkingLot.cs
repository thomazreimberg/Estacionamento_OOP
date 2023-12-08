using System.Text;

namespace Estacionamento_Application;

public class ParkingLot
{
    private List<(Vehicle Vehicle, VehicleSize ParkedIn)> _parkedVehicles;

    public int TotalSpacesLeft { 
        get 
        { 
            return TotalMotorcycleSpots + TotalCarSpots + TotalVanSpots - 
                OccupiedSpaces<Motorcycle>() - OccupiedSpaces<Car>() - OccupiedSpaces<Van>(); 
        } 
    }

    public int TotalSpacesInParkingLot
    {
        get
        {
            return TotalMotorcycleSpots + TotalCarSpots + TotalVanSpots;
        }
    }

    public int TotalMotorcycleSpots { get; private set; }
    public int TotalCarSpots { get; private set; }
    public int TotalVanSpots { get; private set; }

    public ParkingLot(int motorcycleSpots, int carSpots, int vanSpots)
    {
        Func<int, int> setSpot = (int spot) => spot >= 0 ? spot : 0;

        _parkedVehicles = new List<(Vehicle Vehicle, VehicleSize ParkedIn)>();
        TotalMotorcycleSpots = setSpot(motorcycleSpots);
        TotalCarSpots = setSpot(carSpots);
        TotalVanSpots = setSpot(vanSpots);
    }

    public bool IsFull => TotalSpacesLeft == 0 && TotalMotorcycleSpots + TotalCarSpots + TotalVanSpots > 0;
    public bool IsEmpty => _parkedVehicles.Count == 0;

    public void ParkVehicle(Vehicle vehicle)
    {
        if (vehicle.CanFitinSpot(this))
        {
            _parkedVehicles.Add((vehicle, vehicle.ParkIn(this)));
            Console.WriteLine($"Veículo ({vehicle.GetType().Name}) estacionado. Vagas restantes: { TotalSpacesLeft }");
        }
        else
            Console.WriteLine($"Estacionamento cheio. Não há vagas disponíveis para veículos do tipo {vehicle.Size}.");
    }

    public void RemoveVehicle()
    {
        if (_parkedVehicles.Count > 0)
        {
            var vehicle = _parkedVehicles[^1].Vehicle;
            _parkedVehicles.RemoveAt(_parkedVehicles.Count - 1);
            Console.WriteLine($"Veículo ({vehicle.GetType().Name})  removido. Vagas restantes: { TotalSpacesLeft }");
        }
        else
            Console.WriteLine("O estacionamento está vazio. Não há veículos para remover.");
    }

    public string AvailableSpaces()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"Motorcycle: {AvailableSpaces<Motorcycle>()}, ");
        stringBuilder.Append($"Car: {AvailableSpaces<Car>()}, ");
        stringBuilder.Append($"Van: {AvailableSpaces<Van>()}.");

        return stringBuilder.ToString();
    }

    public bool IsTypeFull<T>() where T : Vehicle, new()
    {
        int totalSpacesOfType = OccupiedSpaces<T>();
        return totalSpacesOfType == TotalSpacesOfType<T>();
    }

    public int OccupiedSpaces<T>() where T : Vehicle, new() =>
        _parkedVehicles
            .FindAll(v => v.ParkedIn == new T().Size)
            .Sum(item => item.ParkedIn != item.Vehicle.Size ? item.Vehicle.GetSpotsNeeded() : 1);

    public int AvailableSpaces<T>() where T : Vehicle, new() => 
        TotalSpacesOfType<T>() - OccupiedSpaces<T>() > 0 ? TotalSpacesOfType<T>() - OccupiedSpaces<T>() : 0;

    private int TotalSpacesOfType<T>() where T : Vehicle, new() =>
        new T() switch
        {
            Motorcycle => TotalMotorcycleSpots,
            Car => TotalCarSpots,
            Van => TotalVanSpots,
            _ => 0,
        };
}
