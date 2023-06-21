using System;

namespace Scopy.Abstract
{
    public interface IScopeProvider<out TScope, T> : IDisposable 
        where TScope : IValueScope<T>, new()
        where T : new()
    {
        T Current { get; }
        TScope CreateScope(T value);
        new void Dispose();
    }
}
