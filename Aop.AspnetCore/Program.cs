using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Aop.AspnetCore.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection(); 
            //services.AddMemoryCache();
            services.AddLogging(cfg => cfg.AddConsole());
            services.AddScoped<IAopService, AopService>();
            // 添加缓存切面
            services.AddAspectCore();
            var aopService =  ServiceLocator.GetService<IAopService>();

            Console.WriteLine("第一次执行Handle");
            //aopService.Handle();
            //aopService.Handle("hello");
            aopService.HandleAsync("hello");


            Console.WriteLine("第二次执行Handle");
            //aopService.Handle();
            //aopService.Handle("hello");
            aopService.HandleAsync("hello");


            Console.ReadLine();
        }
    }
}
