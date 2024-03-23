// See https://aka.ms/new-console-template for more information

// Console.WriteLine("Started lab2");

using System.ComponentModel;
using lab2.Containers;

namespace lab2;

public class AppLogistics
{
    public static void Main(String[] args)
    {
        Liquid liquid = new Liquid();
        liquid.GetSerialNumber();
        Gas gas = new Gas(2);
        gas.GetSerialNumber();
        // gas.LoadCargo(600);
        // gas.NotifyHazard(gas.GetSerialNumber());
        // gas.LoadCargo(cargoMass:40540);
        // gas.NotifyHazard(containerNumber:"3");
        Refrigerated refrigerated = new Refrigerated(ProductType.Meat,-2);
        refrigerated.LoadCargo(454);
        // refrigerated.LoadCargo(322);
        // // gas.ToString();
        // Console.WriteLine(gas.ToString());
        Console.WriteLine(refrigerated.ToString());
        var refrigeratedHeight = refrigerated.Height;
        Console.WriteLine(refrigeratedHeight);
    }
    
    
}