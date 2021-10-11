using System;
using System.Collections.Generic;
using System.Text;

namespace Aop.AspnetCore
{
    public interface ICacheProvider
    {
        T Get<T>(string key);

        bool TryGetValue(string key, out object value);

        void Set<T>(string key, T value, TimeSpan? expireTimeSpan = null);
    }
}
