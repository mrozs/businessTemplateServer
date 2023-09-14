using tm.Core.Abstractions;

namespace tm.Infrastructure.Time;

public class Clock: IClock
{
    public DateTime Current() => DateTime.UtcNow;
}
