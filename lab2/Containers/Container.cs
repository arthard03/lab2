using lab2.Containers.Exceptions;

namespace lab2.Containers;

public abstract class Container: IHazardNotifier
{
    public double mass { get; set; }
    public double height { get; set; }
    public double TareWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public double maxWeight { get; set; }


    public Container(String type)
    {
        Guid myuiid = Guid.NewGuid();
        string code = myuiid.ToString();
        this.SerialNumber = code;
        SerialNumber = ("KON-"+type+"-"+code);

    }
    

    public virtual void loadCargo(double CargoMass)
    {
        if (CargoMass > maxWeight)
            throw new OverfillException("Exceed weight of the container");
    }

    public virtual void EmptyCargo()
    {
        this.mass = 0;
    }

    public virtual string GetSerialNumber()
    {
        return SerialNumber;
    }
    public virtual void NotifyHazard(string containerNumber)
    {
        // Default implementation for containers that might not need it
        Console.WriteLine($"Hazardous situation with container {containerNumber}");
    }
}