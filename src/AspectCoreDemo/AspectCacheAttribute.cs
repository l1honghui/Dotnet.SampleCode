using AspectCore.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Aop.AspnetCore
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AspectCacheAttribute : BaseAspectAttribute
    {
        /// <summary>
        /// 缓存有限期，单位：分钟，默认值：10
        /// </summary>
        public int Expiration { get; set; } = 10;

        /// <summary>
        /// 缓存key值，默认为null，不指定则按内部规则产生key值
        /// </summary>
        public string CacheKey { get; set; } = null;

        private readonly ICacheProvider _cache = ServiceLocator.GetService<ICacheProvider>();


        public override async Task Handle(AspectContext context, AspectDelegate next)
        {
            var key = string.IsNullOrWhiteSpace(CacheKey)
                  ? CacheKeyGenerator.GetMemoryCacheKey(context.ServiceMethod, context.Parameters)
                  : CacheKey;
            if (_cache.TryGetValue(key, out var value))
            {
                if (context.ServiceMethod.IsReturnTask())
                {
                    if (value == null)
                    {
                        context.ReturnValue = Task.FromResult((object)null);
                    }
                    else
                    {
                        dynamic temp = value;
                        context.ReturnValue = Task.FromResult(temp);
                    }
                }
                else
                {
                    context.ReturnValue = value;
                }
                Logger.LogInformation($"AspectCacheAttribute：缓存为Key:{key}，获取到缓存，返回缓存值。");
            }
            else
            {
                await next(context);
                dynamic returnValue = context.ReturnValue;
                if (context.ServiceMethod.IsReturnTask())
                {
                    returnValue = returnValue.Result;
                }

                _cache.Set(key, (object)returnValue, TimeSpan.FromMinutes(Expiration));

                Logger.LogInformation($"AspectCacheAttribute：缓存为Key:{key}，没有获取到缓存，添加缓存完成，过期时间为:{Expiration}分钟。");
            }
        }
    }
}
