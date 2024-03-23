
namespace lab2.Containers
{
    public enum ProductType
    {
        Meat, Diary, Fruit, Readymadefood
    }

    public class Refrigerated : Container
    {
        public ProductType ProductType { get; private set; }
        public int Temperature { get; private set; } 

        public Refrigerated(ProductType productType, int temperature) : base("Rf")
        {
            ProductType = productType;
            Temperature = temperature;
         
            TareWeight = 600;

            try
            {
                ValidateTemperatureRange();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wrong temperature for the product: "+ProductType);
            }
        }
        private void ValidateTemperatureRange()
        {
            var minTemp = GetMinimumTemperature(ProductType);
            var maxTemp = GetMaximumTemperature(ProductType);
            if (Temperature < minTemp || Temperature > maxTemp)
            {

                throw new Exception("Not the right temperature");
            }
        }

   
        private int GetMinimumTemperature(ProductType productType)
        {
            if (productType == ProductType.Meat)
            {
                return -5;
            }
            else if (productType == ProductType.Diary)
            {
                return 2;
            }
            else if (productType == ProductType.Fruit)
            {
                return 7;
            }
            else if (productType == ProductType.Readymadefood)
            {
                return -1;
            }
            else
            {
                throw new ArgumentException("Unsupported product type.");
            }
        }

        private int GetMaximumTemperature(ProductType productType)
        {
            if (productType == ProductType.Meat)
            {
                return 2;
            }
            else if (productType == ProductType.Diary)
            {
                return 5;
            }
            else if (productType == ProductType.Fruit)
            {
                return 10;
            }
            else if (productType == ProductType.Readymadefood)
            {
                return 3;
            }
            else
            {
                throw new ArgumentException("Unsupported product type.");
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
