using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;
using System;
using System.Net;
using System.Security.Cryptography;

namespace toll_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var tollCalc = new TollCalculator();

            var car = new Car();
            var taxi = new Taxi();
            var bus = new Bus();
            var truck = new DeliveryTruck();

            Console.WriteLine($"The toll for a car is {tollCalc.CalculateToll(car)}");
            Console.WriteLine($"The toll for a taxi is {tollCalc.CalculateToll(taxi)}");
            Console.WriteLine($"The toll for a bus is {tollCalc.CalculateToll(bus)}");
            Console.WriteLine($"The toll for a truck is {tollCalc.CalculateToll(truck)}");

            try
            {
                tollCalc.CalculateToll("this will fail");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Caught an argument exception when using the wrong type");
            }
            try
            {
                tollCalc.CalculateToll(null);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Caught an argument exception when using null");
            }
        }
    }

    public class TollCalculator
    {

        public decimal CalculateToll(object vehicle)
        {
            //return vehicle switch
            //{
            //    Car c => 2.00m,
            //    Taxi t => 3.50m,
            //    Bus b => 5.00m,
            //    DeliveryTruck t => 10.00m,
            //    { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
            //    null => throw new ArgumentNullException(nameof(vehicle))
            //};

            //添加因乘客数而异的定价
            //return vehicle switch
            //{
            //    Car { Passengers: 0 } => 2.00m + 0.50m,
            //    Car { Passengers: 1 } => 2.00m,
            //    Car { Passengers: 2 } => 2.00m - 0.50m,
            //    Car c => 2.00m - 1.0m,

            //    Taxi { Fares: 0 } => 3.5m + 1.0m,
            //    Taxi { Fares: 1 } => 3.5m,
            //    Taxi { Fares: 2 } => 3.5m - 0.5m,
            //    Taxi t => 3.50m - 1.0m,

            //    Bus b when ((double)b.Riders / (double)b.Capacity) < 0.50 => 5.00m + 2.00m,
            //    Bus b when ((double)b.Riders / (double)b.Capacity) > 0.90 => 5.00m - 1.00m,
            //    Bus b => 5.00m,

            //    DeliveryTruck t when (t.GrossWeightClass > 5000) => 10.00m + 5.00m,
            //    DeliveryTruck t when (t.GrossWeightClass < 3000) => 10.00m - 2.00m,
            //    DeliveryTruck t => 10.00m,

            //    { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
            //    null => throw new ArgumentNullException(nameof(vehicle))
            //};

            //近一步简化
            return vehicle switch
            {
                Car c => c.Passengers switch
                {
                    0 => 2.0m + 0.5m,
                    1 => 2.0m + 0.5m,
                    2 => 2.0m + 0.5m,
                    _ => 2.0m - 1.0m,
                },
                Taxi t => t.Fares switch
                {
                    0 => 3.5m + 1.0m,
                    1 => 3.5m,
                    2 => 3.5m - 0.5m,
                    _ => 3.5m - 1.0m
                },

                Bus b when ((double)b.Riders / (double)b.Capacity) < 0.5 => 5.0m + 2.0m,
                Bus b when ((double)b.Riders / (double)b.Capacity) > 0.9 => 5.0m + 1.0m,
                Bus b => 5.0m,

                DeliveryTruck t when (t.GrossWeightClass > 5000) => 10.0m + 5.0m,
                DeliveryTruck t when (t.GrossWeightClass < 3000) => 10.0m - 2.0m,
                DeliveryTruck t => 10.0m,
                { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
                null => throw new ArgumentNullException(nameof(vehicle))
            };
        }

        //添加高峰时段定价
        //用函数匹配模式确定今天是否是工作日
        //private static bool IsWeekDay(DateTime timeOfToll) =>
        //    timeOfToll.DayOfWeek switch
        //    {
        //        DayOfWeek.Monday => true,
        //        DayOfWeek.Tuesday => true,
        //        DayOfWeek.Wednesday => true,
        //        DayOfWeek.Thursday => true,
        //        DayOfWeek.Friday => true,
        //        DayOfWeek.Saturday => false,
        //        DayOfWeek.Sunday => false
        //    };
        //简化模式
        private static bool IsWeekDay(DateTime timeOfToll) =>
         timeOfToll.DayOfWeek switch
         {
             DayOfWeek.Saturday => false,
             DayOfWeek.Sunday => false,
             _ => true,
         };

        //将时间分为块的类似函数，即将时间段分为早晚高峰及平时
        private enum TimeBand
        {
            MorningRush,
            Daytime,
            EveningRush,
            Overnight,
        }

        private static TimeBand GetTimeBrand(DateTime timeOfToll)
        {
            int hour = timeOfToll.Hour;
            if (hour < 6)
            {
                return TimeBand.Overnight;
            }
            else if (hour < 10)
            {
                return TimeBand.MorningRush;
            }
            else if (hour < 16)
            {
                return TimeBand.Daytime;
            }
            else if (hour < 20)
            {
                return TimeBand.EveningRush;
            }
            else
            {
                return TimeBand.Overnight;
            }
        }

        //计算定价附加费
        public decimal PeakTimePremiumFull(DateTime timeOfToll, bool inbound) => (IsWeekDay(timeOfToll), GetTimeBrand(timeOfToll), inbound) switch
        {
            //(true, TimeBand.MorningRush, true) => 2.00m,
            //(true, TimeBand.MorningRush, false) => 1.00m,
            //(true, TimeBand.Daytime, true) => 1.50m,
            //(true, TimeBand.Daytime, false) => 1.50m,
            //(true, TimeBand.EveningRush, true) => 1.00m,
            //(true, TimeBand.EveningRush, false) => 2.00m,
            //(true, TimeBand.Overnight, true) => 0.75m,
            //(true, TimeBand.Overnight, false) => 0.75m,
            //(false, TimeBand.MorningRush, true) => 1.00m,
            //(false, TimeBand.MorningRush, false) => 1.00m,
            //(false, TimeBand.Daytime, true) => 1.00m,
            //(false, TimeBand.Daytime, false) => 1.00m,
            //(false, TimeBand.EveningRush, true) => 1.00m,
            //(false, TimeBand.EveningRush, false) => 1.00m,
            //(false, TimeBand.Overnight, true) => 1.00m,
            //(false, TimeBand.Overnight, false) => 1.00m,

            //进一步简化
            //(true, TimeBand.MorningRush, true) => 2.00m,
            //(true, TimeBand.MorningRush, false) => 1.00m,
            //(true, TimeBand.Daytime, _) => 1.50m,
            //(true, TimeBand.EveningRush, true) => 1.00m,
            //(true, TimeBand.EveningRush, false) => 2.00m,
            //(true, TimeBand.Overnight, _) => 0.75m,
            //(false, _, _) => 1.00m,

            //最后简化
            (true, TimeBand.Overnight, _) => 0.75m,
            (true, TimeBand.Daytime, _) => 1.5m,
            (true, TimeBand.MorningRush, true) => 2.0m,
            (true, TimeBand.EveningRush, false) => 2.0m,
            (_, _, _) => 1.0m,
        };
    }


}
