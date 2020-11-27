using System;

namespace Slova.Dictionary.Infrastructure
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
        
        public DateTime Now => DateTime.Now;
    }
}