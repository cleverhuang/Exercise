using System;

namespace Use_Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct)]
    public class MySpecialAttribute:Attribute
    {

    }

    [MySpecial]
    public class SomeOtherClass
    {
        public int MyProperty { get; set; }
    }
}
