namespace Scopy.Implementation
{
    public sealed class ScopeFactory
    {
        public TimeScopeProvider UseTimeScope() => new();
    }
}
