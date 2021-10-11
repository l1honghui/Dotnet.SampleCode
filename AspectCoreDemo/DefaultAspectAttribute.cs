using AspectCore.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aop.AspnetCore
{
    public class DefaultAspectAttribute : BaseAspectAttribute
    {
        public override async Task Handle(AspectContext context, AspectDelegate next)
        {
            await next(context);
        }
    }
}
