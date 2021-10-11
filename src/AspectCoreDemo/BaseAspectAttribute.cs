using AspectCore.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aop.AspnetCore
{
    public abstract class BaseAspectAttribute : AbstractInterceptorAttribute
    {
        protected readonly ILogger<BaseAspectAttribute> Logger = ServiceLocator.GetService<ILogger<BaseAspectAttribute>>();

        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            Logger.LogInformation($"开始执行方法:{context.ServiceMethod.Name}，参数:{string.Join("_", context.Parameters)}");
            try
            {
                await Handle(context, next);
            }
            catch (Exception ex)
            {
                Logger.LogInformation($"执行方法异常:{context.ServiceMethod.Name}");
                throw ex;
            }
            finally
            {
                Logger.LogInformation($"结束执行方法:{context.ServiceMethod.Name}");
            }
        }

        public abstract Task Handle(AspectContext context, AspectDelegate next);
    }
}
