using System;

namespace MoodAnalyser
{
    
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            
            Customer c = new Customer(5, "Kalpesh");
            c.PrintId();
            c.PrintName();
            ReflectionTest.Test();
        }
    }
}
