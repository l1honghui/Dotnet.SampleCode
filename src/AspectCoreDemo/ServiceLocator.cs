using Microsoft.Extensions.DependencyInjection;
using System;

namespace Aop.AspnetCore
{
    public class ServiceLocator
    {
        private static IServiceProvider _serviceProvider;

        public static void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static IServiceScope CreateServiceScope()
        {
            return _serviceProvider.CreateScope();
        }

        public static IServiceProvider CreateServiceProvider()
        {
            return CreateServiceScope().ServiceProvider;
        }

        /// <summary>
        /// 获取服务，未找到返回null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>() where T : class
        {
            return CreateServiceProvider().GetService<T>();
        }
    }
}
