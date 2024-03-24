// See https://aka.ms/new-console-template for more information

// Console.WriteLine("Started lab2");

using System.ComponentModel;
using lab2.Containers;
using Container = lab2.Containers.Container;

namespace lab2;

public class AppLogistics
{
    public static void Main(String[] args)
    {
        // Liquid liquid = new Liquid();
        // liquid.GetSerialNumber();
        // Gas gas = new Gas(2);
        // gas.GetSerialNumber();
        // // gas.LoadCargo(600);
        // // gas.NotifyHazard(gas.GetSerialNumber());
        // // gas.LoadCargo(cargoMass:40540);
        // // gas.NotifyHazard(containerNumber:"3");
        // Refrigerated refrigerated = new Refrigerated(ProductType.Meat,-2);
        // refrigerated.LoadCargo(454);
        // // refrigerated.LoadCargo(322);
        // // // gas.ToString();
        // // Console.WriteLine(gas.ToString());
        // Console.WriteLine(refrigerated.ToString());
        // var refrigeratedHeight = refrigerated.Height;
        // Console.WriteLine(refrigeratedHeight);
        Ship myShip = new Ship(25, 100, 10022);

        Container gasContainer = myShip.CreateContainer("Gas", 5.0);
        Container liquidContainer = myShip.CreateContainer("Liquid");
        Container refrigeratedContainer = myShip.CreateContainer("Refrigerated", ProductType.Meat, -2);
        Container anotherGasContainer = myShip.CreateContainer("Gas", 2.2);

        myShip.LoadCargo(gasContainer, 400);
        myShip.LoadCargo(liquidContainer, 500);
            myShip.LoadCargo(refrigeratedContainer, 200);
            myShip.LoadCargo(refrigeratedContainer, 200);

            try
            {
                myShip.LoadContainer(anotherGasContainer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<Container> containersToLoad = new List<Container>() { gasContainer, liquidContainer, refrigeratedContainer };
            myShip.LoadContainers(containersToLoad);

            Console.WriteLine("Initial Ship Information: ");
            myShip.PrintShipInfo();

            Container removedContainer = myShip.containers[0];
            myShip.RemoveContainer(removedContainer);

            myShip.UnloadContainer(liquidContainer);

            Console.WriteLine("Ship Information After Changes: ");
            myShip.PrintShipInfo();

            Ship otherShip = new Ship(10, 50, 5000);

            myShip.ReplaceContainer(refrigeratedContainer, new Refrigerated(ProductType.Meat, -2));

            myShip.TransferContainer(otherShip, removedContainer);

            Console.WriteLine("Information About  Ships");
            Console.WriteLine("My Ship: ");
            myShip.PrintShipInfo();
            Console.WriteLine("Other Ship: ");
            otherShip.PrintShipInfo();
        
    }
    
    
}