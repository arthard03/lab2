using lab2.Containers.Exceptions;

namespace lab2.Containers;

public abstract class Container : IHazardNotifier
{
    public double Mass { get; set; }
    public int Height { get; set; }
    public double TareWeight { get; set; }
    public int Depth { get; set; }
    public string SerialNumber { get; set; }
    public abstract object GetAdditionalInformation(); 


    private Random rand = new Random();
    public Container(String type)
    {
        Guid myuiid = Guid.NewGuid();
        string code = myuiid.ToString();
        this.SerialNumber = code;
        SerialNumber = ("KON-" + type + "-" + code);
        this.Height = (int)(rand.NextDouble() * (50 - 5) + 5);
        this.Depth =  (int)(rand.NextDouble() * (100 - 5) + 5);
    }


    public  virtual void LoadCargo(int cargoMass)
    {
        try
        {
            if (cargoMass > TareWeight)
            {
                throw new OverfillException("Cargo mass exceeds container capacity");
            }
            this.Mass += cargoMass;
        }
        catch (OverfillException)
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