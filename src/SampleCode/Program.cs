using System;

namespace SampleCode
{

    class Program
    {
        public static void Main()
        {
            SystemInfos.SystemInfo.PrintSystemInfo();

            Console.ReadKey();
        }
        public static void WriteLine(object obj)
        {
            Console.WriteLine(obj);
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
