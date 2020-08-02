using System;
using System.Reflection;
using System.Security.Cryptography;
using static System.Console;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type t = typeof(SimpleClass);
            //BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Public;

            //MemberInfo[] members = t.GetMembers(flags);
            //Console.WriteLine($"Type {t.Name} has {members.Length} members: ");
            //foreach (var member in members)
            //{
            //    string access = "";
            //    string stat = "";
            //    var method = member as MethodBase;
            //    if (method != null)
            //    {
            //        if (method.IsPublic)
            //        {
            //            access = " Public";
            //        }
            //        else if (method.IsPrivate)
            //        {
            //            access = " Private";
            //        }
            //        else if (method.IsFamily)
            //        {
            //            access = " Protected";
            //        }
            //        else if (method.IsAssembly)
            //        {
            //            access = " Internal";
            //        }
            //        else if (method.IsFamilyOrAssembly)
            //        {
            //            access = " Protected Internal ";
            //        }
            //        if (method.IsStatic)
            //        {
            //            stat = " Static";
            //        }
            //    }

            //    var output = $"{member.Name} ({member.MemberType}): {access}{stat}, Declared by {member.DeclaringType}";
            //    Console.WriteLine(output);
            //}

            //var packard = new Automobile("Packard", "Custom Eight", 1948);
            //Console.WriteLine(packard);


            //var book = new Book("The Tempest", "0971655819", "Shakespeare, William", "Public Domain Press");

            //ShowPublicationInfo(book);
            //book.Publish(new DateTime(2016, 8, 18));
            //ShowPublicationInfo(book);

            //var book2 = new Book("The Tempest", "Classic Works Press", "Shakespeare, William");
            //Write($"{book.Title} and {book2.Title} are the same publication: " +
            //      $"{((Publication)book).Equals(book2)}");

            Shape[] shapes = { new Rectangle(10, 12), new Square(5), new Circle(3) };

            foreach (var shape in shapes)
            {
                System.Console.WriteLine($"{shape}:area,{Shape.GetArea(shape)}; perimeter,{Shape.GetPerimeter(shape)}");

                var rect = shape as Rectangle;
                if (rect!=null)
                {
                    Console.WriteLine($"   Is Square: {rect.IsSquare()}, Diagonal: {rect.Diagonal}");
                    continue;
                }
                var sq = shape as Square;
                if (sq!=null)
                {
                    Console.WriteLine($"   Diagonal: {sq.Diagonal}");
                    continue;
                }
            }

            

        }

        private static void ShowPublicationInfo(Publication pub)
        {
            string pubDate = pub.GetPublicationDate();
            WriteLine($"{pub.Title}, " + $"{(pubDate == "NYP" ? "Not Yet Published" : "published on " + pubDate):d} by {pub.Publisher}");

        }
    }

}