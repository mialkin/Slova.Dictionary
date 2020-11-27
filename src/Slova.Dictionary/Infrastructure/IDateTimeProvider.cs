using System;

namespace Slova.Dictionary.Infrastructure
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
        
        DateTime Now { get; }
    }
}