using lab2.Containers.Exceptions;

namespace lab2.Containers;

public class Liquid: Container,IHazardNotifier
{
    public int MaxWeight = 450;
    public int Mass;
    public bool HazardousCargo { get; private set; }

    public Liquid():base("Lq")
    {
    }
    public int GetAvailableCapacity()
    {
        return HazardousCargo ? MaxWeight / 2 : MaxWeight * 9 / 10;
    }
    public void LoadCargo(int cargoMass)
    {
        if (cargoMass > GetAvailableCapacity())
        {
            throw new OverfillException("Cargo mass exceeds container capacity");
        }
        Mass += cargoMass;
    }
    // public void NotifyHazard(string containerNumber)
    // {
    //     Console.WriteLine($"Hazardous situation with liquid container {containerNumber}");
    // }
    public void NotifyHazard(string containerNumber)
    {
    }
}
