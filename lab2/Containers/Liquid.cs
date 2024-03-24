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
        TareWeight = this.TareWeight;
        if (HazardousCargo)
        {
            return TareWeight * 0.5;
        }
        else
        {
            return TareWeight * 0.9;
        }

        return TareWeight;
    }


    public override object GetAdditionalInformation()
    {
        return new
        {
            Depth,
            Height,
            HazardousCargo
        };
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

            Mass += cargoMass;
        }
        catch (OverfillException)
        {
            Console.WriteLine("Overfill container ");
        }
    }

    public new void NotifyHazard(string containerNumber)
    {
        Console.WriteLine("Hazardous situation with liquid container: "+containerNumber);
    }
    
}
