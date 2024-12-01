using System;

namespace MintaZhMegoldas_PMP
{
    public enum CountryName
    {
        Australia = 1, Brazil = 2, Canada = 3, France = 4, Germany = 5, Italy = 6, Mexico = 7,
        Spain = 8, UnitedKingdom = 9, UnitedStates = 10
    }

    public enum SubscriptionType
    {
        Basic, Premium, Standard
    }

    public enum DeviceType
    {
        Laptop, SmartTV, Smartphone, Tablet
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dataset ds = new Dataset("netflix_data.csv");
            string a = ds.DistributionOfDeviceType(DeviceType.Laptop);
            Console.WriteLine(a);
        }
    }
}
