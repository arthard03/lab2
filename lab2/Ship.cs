using lab2.Containers;

namespace lab2
{
    public class Ship
    {
        public List<Container> containers = new List<Container>();
        public int Speed { get; set; }
        public int MaxContainerCount { get; set; }
        public int MaxContainerWeight { get; set; }

        public Ship(int speed, int maxContainerCount, int maxContainerWeight)
        {
            Speed = speed;
            MaxContainerCount = maxContainerCount;
            MaxContainerWeight = maxContainerWeight;
        }

        public Container CreateContainer(string type, params object[] args)
        {
            switch (type)
            {
                case "Gas":
                    return new Gas((double)args[0]);
                case "Liquid":
                    return new Liquid();
                case "Refrigerated":
                    return new Refrigerated((ProductType)args[0], (int)args[1]);
                default:
                    throw new ArgumentException("Invalid container type");
            }
        }

        public void LoadCargo(Container container, int cargoMass)
        {
            container.LoadCargo(cargoMass);
        }

        public void LoadContainer(Container container)
        {
            if (containers.Count >= MaxContainerCount ||
                containers.Sum(c => c.Mass) + container.Mass > MaxContainerWeight)
            {
                throw new Exception("Cannot load container: ship capacity exceeded");
            }

            containers.Add(container);
        }

        public void LoadContainers(List<Container> containersToLoad)
        {
            foreach (Container container in containersToLoad)
            {
                try
                {
                    LoadContainer(container);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading container: {ex.Message}");
                }
            }
        }

        public void RemoveContainer(Container container)
        {
            containers.Remove(container);
        }

        public void UnloadContainer(Container container)
        {
            if (container is Refrigerated refrigeratedContainer)
            {
                refrigeratedContainer.EmptyCargo(); 
                container.Mass = 0;
            }
            else
            {
                container.EmptyCargo(); 
            }
        }

        public void ReplaceContainer(Container oldContainer, Container newContainer)
        {
            int index = containers.IndexOf(oldContainer);
            if (index != -1)
            {
                containers[index] = newContainer;
            }
            else
            {
                throw new ArgumentException("Container not found");
            }
        }

        public void TransferContainer(Ship otherShip, Container container)
        {
            RemoveContainer(container);
            otherShip.LoadContainer(container);
        }

        public void PrintContainerInfo(Container container)
        {
            Console.WriteLine("Container serial number: " + container.GetSerialNumber());
            Console.WriteLine("Container type: " + container.GetType().Name);
            Console.WriteLine("Container mass: " + container.Mass);
            object additionalInfo = container.GetAdditionalInformation();
            Console.WriteLine("Additional Information:");
            Console.WriteLine(additionalInfo);
        }


        public void PrintShipInfo()
        {
            Console.WriteLine("Ship speed: " + Speed);
            Console.WriteLine("Ship capacity containers: " + MaxContainerCount);
            Console.WriteLine("Ship weight capacity: " + MaxContainerWeight);
            Console.WriteLine("Loaded Containers:");
            foreach (Container container in containers)
            {
                PrintContainerInfo(container);
            }
        }
    }
}