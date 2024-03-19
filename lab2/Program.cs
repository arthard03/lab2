// See https://aka.ms/new-console-template for more information

// Console.WriteLine("Started lab2");

class OverfillException : Exception
{
    public OverfillException(string message) : base(message)
    {
        
    }
}


public class Container
{
    public double mass { get; set; }
    public double height { get; set; }
    public double TareWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumbe { get; set; }
    public double maxWeight { get; set; }
    public string getIntials { get; set; }

    public Container(string getIntials)
    {
        this.getIntials = getIntials;
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

    public virtual void GetCode()
    {
        Guid myuiid = Guid.NewGuid();
        string code = myuiid.ToString();
        Console.WriteLine("KON-"+getIntials+"-"+code);
    }
}

public class RefrigiratorContainer : Container
{
   public  string Type { get; set; }
   public  double Temperature { get; set; }

   public RefrigiratorContainer(string type, double temperature) : base(getIntials:"Rf")
   {
       Type = type;
       Temperature = temperature;
   }


}

public class LiquidContainer : Container
{
    public LiquidContainer(string getIntials) : base(getIntials:"Lq")
    {
    }
}

public class GasContainer : Container
{
    public GasContainer(string getIntials) : base(getIntials:"Gs")
    {
    }
}


public class AppLogistics
{
    public static void Main(String[] args)
    {
        LiquidContainer liquidContainer = new LiquidContainer(getIntials:"Rf");
        liquidContainer.GetCode();
    }
    
}