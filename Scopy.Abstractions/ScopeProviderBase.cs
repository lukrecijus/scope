using System;
using System.Collections.Concurrent;

namespace Scopy.Abstract
{
    public abstract class ScopeProviderBase<TScope, T> : IScopeProvider<TScope, T> 
        where TScope : IValueScope<T>, new()
        where T : new()
    {
        private readonly ConcurrentStack<TScope> _scopeStack;
        
        public T Current
        {
            get
            {
                _scopeStack.TryPeek(out var scope);
                return scope == null 
                    ? default 
                    : scope.Value;
            }
        }
        
        protected ScopeProviderBase()
        {
            _scopeStack = new ConcurrentStack<TScope>();
        }
        
        public TScope CreateScope(T value)
        {
            var scope = new TScope { Value = value };
            _scopeStack.Push(scope);
            return scope;
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _scopeStack.TryPop(out _);
        }
    }
}
