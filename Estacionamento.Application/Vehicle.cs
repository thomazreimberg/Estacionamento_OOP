namespace Estacionamento_Application;

public abstract class Vehicle
{
    public int SpotsNeeded;
    public VehicleSize Size;

    public int GetSpotsNeeded()
    {
        return SpotsNeeded;
    }

    public bool CanFitinSpot(ParkingLot spot) =>
        ParkIn(spot) != VehicleSize.NotAvaliable;

    public abstract VehicleSize ParkIn(ParkingLot spot);
}

//Classes no mesmo arquivo para fins de melhor exibição.
public enum VehicleSize
{ 
    Motorcycle,
    Car,
    Van,
    NotAvaliable
}

public class Motorcycle : Vehicle
{
    public Motorcycle()
    {
        SpotsNeeded = 1;
    }

    public override VehicleSize ParkIn(ParkingLot spot)
    {
        if (spot.AvailableSpaces<Motorcycle>() >  0)
            return VehicleSize.Motorcycle;
        else if (spot.AvailableSpaces<Car>() > 0)
            return VehicleSize.Car;
        else if (spot.AvailableSpaces<Van>() > 0)
            return VehicleSize.Van;
        else
            return VehicleSize.NotAvaliable;
    }
}

public class Car : Vehicle
{
    public Car()
    {
        SpotsNeeded = 1;
        Size = VehicleSize.Car;
    }

    public override VehicleSize ParkIn(ParkingLot spot)
    {
        if (spot.AvailableSpaces<Car>() > 0)
            return VehicleSize.Car;
        else if (spot.AvailableSpaces<Van>() > 0)
            return VehicleSize.Van;
        else
            return VehicleSize.NotAvaliable;
    }
}

public class Van : Vehicle
{
    public Van()
    {
        SpotsNeeded = 3;
        Size = VehicleSize.Van;
    }

    public override VehicleSize ParkIn(ParkingLot spot)
    {
        if (spot.AvailableSpaces<Van>() > 0)
            return VehicleSize.Van;
        else if (spot.AvailableSpaces<Car>() >= SpotsNeeded)
            return VehicleSize.Car;
        else
            return VehicleSize.NotAvaliable;
    }
}
