namespace InterfaceProblem
{
    interface IVehiculo
    {
        public void Drive();
        public bool Refuel(int amount);

    }
    class Car : IVehiculo
    {
        public int gasolineAmount;

        public Car(int startingGasolineAmount)
        {
            gasolineAmount = startingGasolineAmount;
        }

        public void Drive()
        {
            if (gasolineAmount > 0)
            {
                Console.WriteLine("Driving");
            }
        }
        public bool Refuel(int amount)
        {

            gasolineAmount += amount;
            return true;

        }
    }

    internal class InterfaceProblem
    {
        static void Main(string[] arg)
        {
            int gasolineRefuelAmount;
            Car car = new Car(0);
            Console.Write("Enter the amount of gasoline to refuel : ");
            gasolineRefuelAmount = Convert.ToInt32(Console.ReadLine());

            car.Refuel(gasolineRefuelAmount);
            car.Drive();

        }
    }
}