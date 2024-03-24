namespace lab2.Containers
{
    public class Gas : Container

    {
        public double Pressure { get;  set; }

        public Gas(double pressure) : base("Gs")
        {
            Pressure = pressure;
            TareWeight = 500;
            Height = Height;

        }


        public override object GetAdditionalInformation()
        {
            return new
            {
                Depth,
                Height,
                Pressure
            };
        }
        public override void EmptyCargo()
        {
            TareWeight = Math.Floor(TareWeight * 0.05);
        }


        public override void NotifyHazard(string containerNumber)
        {
            Console.WriteLine("Gas leak ,Container serial number: " + containerNumber);
        }

      
    }

}