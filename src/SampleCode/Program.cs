using System;
using System.Diagnostics;

namespace SampleCode
{

    class Program
    {
        public static void Main()
        {
            string content = "content-length:123";
            write(int.Parse(content.Substring(15)));
            Stopwatch watch = new Stopwatch();
            watch.Start();
            write($"int.Parse(content.Substring(15)) = {int.Parse(content.Substring(15))}");
            for (int j = 0; j < 100000; j++)
            {
                int.Parse(content.Substring(15));
            }
            Console.WriteLine("Time Elapsed:" + watch.ElapsedMilliseconds.ToString("N0") + "ms");

            watch.Restart();
            Span<char> span = content.ToCharArray();
            write($"int.Parse(span.Slice(15)) = {int.Parse(span.Slice(15))}");
            for (int j = 0; j < 100000; j++)
            {
                int.Parse(span.Slice(15));
            }
            Console.WriteLine("Time Elapsed:" + watch.ElapsedMilliseconds.ToString("N0") + "ms");

            Console.ReadKey();
        }
        public static void write(object obj)
        {
            Console.WriteLine(obj);
        }
        public static void write(Span<int> obj)
        {
            Console.WriteLine(obj.Length);
        }

        /// <summary> 
        /// 获取时间戳 10位
        /// </summary> 
        /// <returns></returns> 
        public static long GetTimeStampTen()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }
       
    }

}
