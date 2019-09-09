using System;
using System.Threading;
using System.Threading.Tasks;
using SampleCode.ObjectPool;

namespace SampleCode
{

    class Program
    {
        public static void Main()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            // Create an opportunity for the user to cancel.
            Task.Run(() =>
            {
                if (Console.ReadKey().KeyChar == 'c' || Console.ReadKey().KeyChar == 'C')
                    cts.Cancel();
            });

            
            DefaultObjectPool<MyClass> objectPool = new DefaultObjectPool<MyClass>(() => new MyClass());
            // Create a high demand for MyClass objects.
            Parallel.For(0, 1000000, (i, loopState) =>
            {
                MyClass mc = objectPool.GetObject();
                Console.CursorLeft = 0;
                // This is the bottleneck in our application. All threads in this loop
                // must serialize their access to the static Console class.
                Console.WriteLine("{0:####.####}", mc.GetValue(i));                 
                    
                objectPool.PutObject(mc);
                if (cts.Token.IsCancellationRequested)
                    loopState.Stop();                 
 
            });
            Console.WriteLine("Press the Enter key to exit.");
            Console.ReadLine();
            cts.Dispose();
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
