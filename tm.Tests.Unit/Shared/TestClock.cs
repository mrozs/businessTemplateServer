using tm.Core.Abstractions;

namespace tm.Tests.Unit.Shared;

internal class TestClock : IClock
{
    public DateTime Current() => new(2022, 08, 11, 12, 0, 0);
}
