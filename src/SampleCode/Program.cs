using System;

namespace SampleCode
{

    class Program
    {
        public static void Main()
        {
            RegexSample.RegexSampleMatch.GetServerConfig(
                "host=127.0.0.1:5000;username=guest;password=guest;");

            Console.ReadKey();
        }

        public static void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }

    }

}
