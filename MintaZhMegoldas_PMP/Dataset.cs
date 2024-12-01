using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZhMegoldas_PMP
{
    internal class Dataset
    {
        List<User> users;
        public Dataset(string sourcePath)
        {
            users = new List<User>();
            foreach (string line in File.ReadLines(sourcePath))
            {
                if (!line.Contains("Subscription Type"))
                {
                    users.Add(new User(line));
                }
            }
        }

        public int HowManyUsers { get { return users.Count; } }

        public double AverageMonthlyRevenue(SubscriptionType type)
        {
            double cnt = 0;
            double sum = 0;

            for (int i = 0; i < users.Count; i++)
            {
                if (type == users[i].SType)
                {
                    sum += users[i].Price;
                    cnt++;
                }
            }
            return Math.Round(sum / cnt,2);
        }

        public User[] CollectNonPayers(int daysNotPayed)
        { 
            List<User> nonPayerUsers = new List<User>();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].DaysSinceLastPayment() >= daysNotPayed)
                {
                    nonPayerUsers.Add(users[i]);
                }
            }
            return nonPayerUsers.ToArray();
        }

        public string MaximalAgeData()
        {
            int maxIdx = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Age > users[maxIdx].Age)
                {
                    maxIdx = i;
                }
            }
            return users[maxIdx].DataAsText(); 
        }

        public string DistributionOfDeviceType(DeviceType type)
        {
            double allInCountry = 0;
            double dTypeUsersInCountry = 0;
            CountryName actualCountry = 0;
            string result = "-- Distribution of Smartphone -- \n";
            for (int i = 1; i <= 10; i++)
            {
                allInCountry = 0;
                dTypeUsersInCountry = 0;
                actualCountry = (CountryName)i;
                ;
                for (int j = 0; j < users.Count; j++)
                {
                    if (users[j].Country == actualCountry)
                    {
                        allInCountry++;
                        if (users[j].DeviceType == type)
                        {
                            dTypeUsersInCountry++;
                        }
                    }
                }
                result += $"{actualCountry}: {Math.Round((dTypeUsersInCountry / allInCountry) * 100.0,2)}% \n";
            }
            result += "-- END --";
            return result;
        }
    }
}
