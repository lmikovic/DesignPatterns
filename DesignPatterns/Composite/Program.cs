using System;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sample1");
            var sample1 = new DrawingElementProgram();
            Console.WriteLine("Sample2");
            Console.WriteLine();
            var sample2 = new FileStructureProgram();
            Console.ReadKey();
        }
    }
}