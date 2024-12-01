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
            bool exit = false;
            Dataset ds = null;
            while (!exit) 
            {
                /*
                 * 1. Load data file
                   2. Get average monthly revenue
                    3. List non-paying users
                    4. Show distribution of devices
                    5. Exit
                 */
                Console.Clear();
                Console.WriteLine("1. Load data file");
                Console.WriteLine("2. Get average monthly revenue");
                Console.WriteLine("3. List non-paying users");
                Console.WriteLine("4. Show distribution of devices");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.WriteLine("Your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice) 
                {
                    case 1:
                        ds = new Dataset("netflix_data.csv");
                        break;
                    case 2:
                        double avg = ds.AverageMonthlyRevenue(SubscriptionType.Standard);
                        break;
                    case 3:
                        User[] asd = ds.CollectNonPayers(10);
                        for (int i = 0; i < asd.Length; i++)
                        {
                            Console.WriteLine(asd[i].Id);
                        }
                        break;
                    case 4:
                        string d = ds.DistributionOfDeviceType(DeviceType.Laptop);
                        Console.WriteLine(d);
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Nincs ilyen menüpont, válassz másikat!");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
