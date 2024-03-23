using System.Security.Cryptography;
using lab2.Containers.Exceptions;

namespace lab2.Containers;

public abstract class Container : IHazardNotifier
{
    public double Mass { get; set; }
    public double Height { get; set; }
    public double TareWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }

    private Random rand = new Random();
    public Container(String type)
    {
        Guid myuiid = Guid.NewGuid();
        string code = myuiid.ToString();
        this.SerialNumber = code;
        SerialNumber = ("KON-" + type + "-" + code);
        this.Height = rand.NextDouble() * (25 - 5) + 5;
    }


    public  virtual void LoadCargo(int cargoMass)
    {
        try
        {
            if (cargoMass > TareWeight)
            {
                throw new OverfillException("Cargo mass exceeds container capacity");
            }
        }
        catch (OverfillException ex)
        {
            Console.WriteLine("Cargo mass exceeds container capacity");
        }
    }

    public virtual void EmptyCargo()
    {
        this.Mass = 0;
    }

    public virtual string GetSerialNumber()
    {
        return SerialNumber;
    }

    public virtual void NotifyHazard(string containerNumber)
    {
        Console.WriteLine("Hazardous situation with container: " + containerNumber);
    }
}