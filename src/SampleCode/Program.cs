using System;

namespace SampleCode
{

    class Program
    {
        public static void Main()
        {
            RegexSample.RegexSampleMatch.GetServerConfig(
                "host=172.16.0.175:5672;username=guest;password=guest;");

            Console.ReadKey();
        }

        public static void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }

    }

}
