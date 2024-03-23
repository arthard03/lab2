using lab2.Containers.Exceptions;

namespace lab2.Containers
{
    public class Gas : Container, IHazardNotifier
    
    {
        public double Pressure { get; private set; }
public int  MaxWeight =450;
public double Mass;
public Gas(double pressure, int maxWeight) : base("G")
{
    Pressure = pressure;
    MaxWeight = maxWeight;
}
        public void LoadCargo(int cargoMass)
        {
            if (cargoMass > MaxWeight)
                throw new OverfillException("Exceeds weight of the container");

            Mass += cargoMass;
        }


        public override void EmptyCargo()
        {
            // Leave 5% of cargo inside the container
            Mass = Math.Floor(Mass * 0.05);
        }


        public override void NotifyHazard(string containerNumber)
        {
            Console.WriteLine($"Gas leak detected! Container serial number: {containerNumber}");
        }
    }
}