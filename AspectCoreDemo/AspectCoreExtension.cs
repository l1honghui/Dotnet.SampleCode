using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aop.AspnetCore
{
    public static class AspectCoreExtension
    {
        public static IServiceCollection AddAspectCore(this IServiceCollection services , Action<IAspectConfiguration> configure = null)
        {
            services.ConfigureDynamicProxy(configure);
            var serviceProvider = services.BuildDynamicProxyProvider();
            ServiceLocator.SetServiceProvider(serviceProvider);
            return services;
        }
    }
}
