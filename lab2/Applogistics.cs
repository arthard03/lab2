// See https://aka.ms/new-console-template for more information

// Console.WriteLine("Started lab2");

using lab2.Containers;



public class AppLogistics
{
    public static void Main(String[] args)
    {
        Liquid liquid = new Liquid();
        liquid.GetSerialNumber();
        Gas gas = new Gas(3,332);
        gas.GetSerialNumber();
        gas.NotifyHazard(gas.GetSerialNumber());
        // gas.LoadCargo(cargoMass:40540);
        // gas.NotifyHazard(containerNumber:"3");
    }
    
    
}