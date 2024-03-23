using lab2.Containers.Exceptions;

namespace lab2.Containers;

public class Liquid: Container,IHazardNotifier
{
 
    public bool HazardousCargo { get;  set; }

    public Liquid():base("Lq")
    {
       TareWeight  = 600;
    }
    public double GetAvailableCapacity()
    {
        if (HazardousCargo)
        {
            return TareWeight / 2;
        }
        else
        {
            return TareWeight* 9 / 10;
        }
    }

    public override void LoadCargo(int cargoMass)
    {
        try
        {
            double availableCapacity = GetAvailableCapacity();
            if (cargoMass > availableCapacity)
            {
                throw new OverfillException("Cargo mass exceeds container capacity");
            }
        }
        catch (OverfillException ex)
        {
            Console.WriteLine("Overfill container ");
        }
    }

    public new void NotifyHazard(string containerNumber)
    {
        Console.WriteLine("Hazardous situation with liquid container: "+containerNumber);
    }
}
