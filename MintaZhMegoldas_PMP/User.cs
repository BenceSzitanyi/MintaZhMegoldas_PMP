using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MintaZhMegoldas_PMP
{
    internal class User
    {
        /*
         Tárolja a felhasználó azonosítószámát (int), előfizetésének típusát (SubscriptionType),
         előfizetési díját (int), a csatlakozás és a legutóbbi díjfizetés dátuma (egy-egy DateTime), a
        felhasználó országát (CountryName), életkorát (int) és eszközének típusát (DeviceType)
        egy-egy privát mezőben.
         */
        int id;
        SubscriptionType sType;
        int price;
        DateTime registDate;
        DateTime payDay;
        CountryName country;
        int age;
        DeviceType deviceType;

        public int Id { get { return id; } }
        public SubscriptionType SType { get { return sType; } }
        public int Price { get { return price; } }
        public DateTime RegistDate { get { return registDate; } }
        public DateTime PayDay { get { return payDay; } }
        public CountryName Country { get { return country; } }
        public int Age { get { return age; } }
        public DeviceType DeviceType { get { return deviceType; } }

        //1528,Standard,12,2022-09-10,2023-07-07,UnitedKingdom,45,SmartTV
        public User(string sourceLine)
        {
            string[] splittedSource = sourceLine.Split(',');
            id = int.Parse(splittedSource[0]);
            sType = (SubscriptionType)Enum.Parse(typeof(SubscriptionType), splittedSource[1]);
            price = int.Parse(splittedSource[2]);
            registDate = DateTime.Parse(splittedSource[3]);
            payDay = DateTime.Parse(splittedSource[4]);
            country = (CountryName)Enum.Parse(typeof(CountryName), splittedSource[5]);
            age = int.Parse(splittedSource[6]);
            deviceType = (DeviceType)Enum.Parse(typeof(DeviceType), splittedSource[7]);
        }

        public int SubscriptionInDays()
        {
            int result = 0;
            TimeSpan ts = DateTime.Today - registDate;
            result = ts.Days;
            
            return result;
        }

        public int DaysSinceLastPayment()
        {
            int result = 0;
            TimeSpan ts = DateTime.Today - payDay;
            result = ts.Days;

            return result;
        }

        public string DataAsText()
        {
            /*User ID: 1528 (UnitedKingdom, Standard, SmartTV). Subscription: 489 days, last
            payment: 189 days.*/
            return $"User ID: {id} ({country}, {sType}, {deviceType}). Subscription: {SubscriptionInDays()}, las payment: {DaysSinceLastPayment()}";
        }
    }
}
