using AspectCore.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Aop.AspnetCore
{
    public class StopwatchAttribute : AbstractInterceptorAttribute
    {
        private readonly ILogger<StopwatchAttribute> _logger = ServiceLocator.GetService<ILogger<StopwatchAttribute>>();


        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var stopwatch = Stopwatch.StartNew();
            await next(context);
            stopwatch.Stop();
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            _logger.LogInformation($"方法执行耗时时间：{elapsedMilliseconds} ms");
        }
    }
}
