using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Feature01
{
    class Program
    {
        static void Main(string[] args)
        {
            //var p = new Person("Bill", " ", "Wagner");
            //Console.WriteLine($"The name,in all caps:{p.AllCaps()}");
            //Console.WriteLine($"The name is: {p}");

            //var phrase = "the quick brown fox jumps over the lazy dog";
            //var wordLength = from word in phrase.Split(' ') select word.Length;
            //var average = wordLength.Average();
            //WriteLine(average);

            //string s = null;
            //char? c = s?[0];
            //Console.WriteLine(c.HasValue);

            //Console.WriteLine(s?.Length);

            //string s = null;
            //bool? hasMore = s?.ToCharArray()?.GetEnumerator()?.MoveNext();
            //Console.WriteLine(hasMore.HasValue && hasMore.Value);

            //bool hasMore = s?.ToCharArray()?.GetEnumerator()?.MoveNext() ?? false;
            //Console.WriteLine(hasMore);

            //try
            //{
            //    string s = null;
            //    Console.WriteLine(s.Length);
            //}
            //catch (Exception e) when (Logexception(e))
            //{

            //}
            //Console.WriteLine("Exception must have been handled");

            //Console.WriteLine(nameof(System.String));
            //int j = 5;
            //Console.WriteLine(nameof(j));
            //List<string> names = new List<string>();
            //Console.WriteLine(nameof(names));


            var messages = new Dictionary<int, string>
            {
                [404] = "Page not found",
                [302] = "Page moved, but left a forwarding address.",
                [500] = "The web server can't come out to play today."
            };

            Console.WriteLine(messages[302]);
        }

        private static bool Logexception(Exception e)
        {
            Console.WriteLine($"\tIn the log routine.Caught {e.GetType()}");
            Console.WriteLine($"\tMessage:{e.Message}");
            return true;
        }

    }
    //public class Path : IEnumerable<Point3D>
    //{
    //    private List<Point3D> points = new List<Point3D>();
    //    public IEnumerator<Point3D> GetEnumerator() => points.GetEnumerator();
    //    IEnumerator IEnumerable.GetEnumerator() => points.GetEnumerator();

    //    public void Add(Point3D pt) => points.Add(pt);
    //}

    //public static class Extensions
    //{
    //    public static void Add(this Path path, double x, double y, double z) => path.Add(new Point3D(x, y, z));
    //}


    public class Person
    {
        /*
         * 
         C# 6.0新增支持
        01 只读自动属性，例如 public string FirstName { get; private set; }
        02 初始化自动属性的支持字段 例如 public string MiddleName { get; } = "";
        03 Expression-Bodied 成员 例如 public override string ToString() => FirstName + " " + LastName;
        04 导入单个类 例如 using static System.Console;
        05 更好的字符串格式 例如   public override string ToString() => $"{FirstName} {LastName}";
        06 快速且简单的 null 检查 例如  Console.WriteLine(s?.Length);
        07 异常筛选器 例如  catch (Exception e) when (Logexception(e))
        08 使用 nameof 例如 Console.WriteLine(nameof(System.String));
        09 新的对象初始化语法 例如 var messages = new Dictionary<int, string>
            {
                [404] = "Page not found",
                [302] = "Page moved, but left a forwarding address.",
                [500] = "The web server can't come out to play today."
            };


         */

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; } = "";

        public Person(string first, string middle, string last)
        {
            FirstName = first;
            LastName = last;
            MiddleName = middle;
        }

        //public override string ToString()
        //{
        //    return FirstName + " " + LastName;
        //}

        //public override string ToString() => FirstName + " " + LastName;

        public override string ToString() => $"{FirstName} {LastName}";

        public string AllCaps() => ToString().ToUpper();

        //public string AllCaps() 
        //{            
        //    return ToString().ToUpper();
        //}

    }

}
