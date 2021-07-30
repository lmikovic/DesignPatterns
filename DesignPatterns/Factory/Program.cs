using Factory.Abstract;
using System;

namespace Factory
{
    /// <summary>
    /// In Factory pattern, we create object without exposing the creation logic to the client and refer to newly created object using a common interface
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Factory method");
            new FactoryMethod();
            Console.WriteLine();
            Console.WriteLine("Abstract Factory");
            new AbstractFactory();
            Console.ReadKey();
        }
    }
}
