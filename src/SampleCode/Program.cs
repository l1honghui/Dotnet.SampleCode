using System;
using System.Threading;
using System.Threading.Tasks;
using SampleCode.ObjectPool;
using SampleCode.ThreadSynchronization;

namespace SampleCode
{

    class Program
    {
        public static void Main()
        {
            AutoResetEventDemo manualResetEventDemo = new AutoResetEventDemo();
            manualResetEventDemo.StartTest();
            Console.ReadKey();
        }

        public static void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }

    }
    // A toy class that requires some resources to create.
    // You can experiment here to measure the performance of the
    // object pool vs. ordinary instantiation.
    class MyClass
    {
        public int[] Nums {get; set;}
        public double GetValue(long i)
        {
            return Math.Sqrt(Nums[i]);
        }
        public MyClass()
        {
            Nums = new int[1000000];
            Random rand = new Random();
            for (int i = 0; i < Nums.Length; i++)
                Nums[i] = rand.Next();
        }
    } 
}
