using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage_Collector
{
    class A
    {
        int speed;
        string name = "abcd";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Heap memory:" + GC.GetTotalMemory(false));
            Console.WriteLine("Heap memory:" + GC.GetTotalMemory(false));
            Console.WriteLine("Heap memory: " + GC.GetTotalMemory(false));
            Console.WriteLine("OS object generation: " + GC.MaxGeneration);
            A obj = new A();
            Console.WriteLine("obj is {0}", GC.GetGeneration(obj));
            GC.Collect(0);
            Console.WriteLine("obj is {0}", GC.GetGeneration(obj));
            for (int i = 0; i < 5000; i++)
            {
                object[] ob = new object[5000];
                ob[i] = new object();
            }
            Console.WriteLine("Heap memory: " + GC.GetTotalMemory(false));
            Console.WriteLine("Heap memory: " + GC.GetTotalMemory(true)); // true=Collect()
            Console.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
            Console.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
            Console.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));
            Console.WriteLine("Heap memory: " + GC.GetTotalMemory(false));
        }
    }
}
