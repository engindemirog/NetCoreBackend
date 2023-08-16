using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception:MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation,System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
                OnSuccess(invocation);
            }
            catch (Exception e)
            {
                OnException(invocation,e);
                throw;
            }
            OnAfter(invocation);
        }
    }
}
