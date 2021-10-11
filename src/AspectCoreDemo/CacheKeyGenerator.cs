using System.Reflection;

namespace Aop.AspnetCore
{
    public class CacheKeyGenerator
    {
        public static string RedisPrefix { get; set; } = "erp";

        public static string GetRedisCacheKey(MethodInfo method, object[] values) =>
            $"{RedisPrefix}:{method.DeclaringType?.Namespace}:{method.DeclaringType?.Name}:{method.Name}:{string.Join("_", values)}";

        public static string GetMemoryCacheKey(MethodInfo method, object[] values) =>
            $"{method.DeclaringType?.Namespace}_{method.DeclaringType?.Name}_{method.Name}_{string.Join("_", values)}";
    }
}
