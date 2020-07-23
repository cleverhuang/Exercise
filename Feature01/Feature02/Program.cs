using System;
using System.Collections.Generic;

/*C# 6.0 字符串内插使用方法*/

namespace Feature02
{
    class Program
    {
        static void Main(string[] args)
        {
            //var name = "Clever";
            //Console.WriteLine($"Hello,{name},It's pleasure to meet you!");

            //这是一个元组（tuple）的声明方式之一
            //var item = (Name: "eggplant", Price: 1.99m, perPackage: 3);

            //var date = DateTime.Now;
            //Console.WriteLine($"On {date:d},the price of {item.Name} was {item.Price:C2} per {item.perPackage} items.");

            //var inventory = new Dictionary<string, int>
            //{
            //    ["hammer, ball pein"] = 18,
            //    ["hammer, cross pein"] = 5,
            //    ["screwdriver, Phillips #2"] = 14
            //};
            //Console.WriteLine($"Inventory on {DateTime.Now:d}");
            //Console.WriteLine(" ");
            //Console.WriteLine($"|{"Item",-25}|{"Quantity",10}|");
            //foreach (var item in inventory)
            //    Console.WriteLine($"|{item.Key,-25}|{item.Value,10}|");

            Console.WriteLine($"[{DateTime.Now,-20:d}] Hour [{DateTime.Now,-10:HH}] [{1063.342,15:N2}] feet");
        }
    }
}
