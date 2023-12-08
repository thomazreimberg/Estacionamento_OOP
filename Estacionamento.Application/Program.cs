using Estacionamento_Application;

internal class Program
{
    private static void Main(string[] args)
    {
        // Criar um estacionamento
        ParkingLot parkingLot = new ParkingLot(2, 10, 1);

        // Exibir configurações dos veículos.
        DisplayVehicleConfiguration();

        // Exibir informações iniciais
        DisplayParkingInfo(parkingLot);

        // Estacionar alguns veículos para teste
        ParkVehicles(parkingLot);

        // Exibir informações após estacionar
        DisplayParkingInfo(parkingLot);

        // Testar outras funcionalidades
        TestFunctionality(parkingLot);

        Console.ReadKey();
    }

    static void DisplayParkingInfo(ParkingLot parkingLot)
    {
        Console.WriteLine($"Vagas totais: {parkingLot.TotalSpacesLeft}");
        Console.WriteLine($"Vagas restantes: {parkingLot.AvailableSpaces()}");
        Console.WriteLine($"O estacionamento {(parkingLot.IsFull ? "está cheio" : "não está cheio")}.");
        Console.WriteLine($"O estacionamento {(parkingLot.IsEmpty ? "está vazio" : "não está vazio")}.");
        Console.WriteLine($"Vagas de moto {(parkingLot.IsTypeFull<Van>() ? "estão cheias" : "não estão cheias")}.");
        Console.WriteLine($"Vagas de van ocupadas: {parkingLot.OccupiedSpaces<Van>()}");
        Console.WriteLine();
    }

    static void ParkVehicles(ParkingLot parkingLot)
    {
        parkingLot.ParkVehicle(new Car());
        parkingLot.ParkVehicle(new Motorcycle());
        parkingLot.ParkVehicle(new Van());
        parkingLot.ParkVehicle(new Car());
        parkingLot.ParkVehicle(new Van());
    }

    static void TestFunctionality(ParkingLot parkingLot)
    {
        Console.WriteLine("Testando outras funcionalidades:");

        if (!parkingLot.IsEmpty)
        {
            Console.WriteLine("Removendo um veículo...");
            parkingLot.RemoveVehicle();
            DisplayParkingInfo(parkingLot);
        }
        else
            Console.WriteLine("O estacionamento está vazio. Não é possível remover veículo.");

        Console.WriteLine("Estacionando mais veículos...");
        ParkVehicles(parkingLot);
        DisplayParkingInfo(parkingLot);
    }

    static void DisplayVehicleConfiguration()
    {
        Console.WriteLine("SpotsNeeded...");
        Console.WriteLine($"Motorcycle: {new Motorcycle().GetSpotsNeeded()}");
        Console.WriteLine($"Car: {new Car().GetSpotsNeeded()}");
        Console.WriteLine($"Van: {new Van().GetSpotsNeeded()}");

        Console.WriteLine();
    }
}