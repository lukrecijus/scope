using System;
using Scopy.Abstract;

namespace Scopy.Implementation
{
    public sealed class TimeScope : IValueScope<DateTime>
    {
        public DateTime Value { get; init; }
    }
}
