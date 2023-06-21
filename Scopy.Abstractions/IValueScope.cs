namespace Scopy.Abstract
{
    public interface IValueScope<T> where T : new()
    {
        public T Value { get; init; }
    }
}
