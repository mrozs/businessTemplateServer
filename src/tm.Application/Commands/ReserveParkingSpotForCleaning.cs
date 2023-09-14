using tm.Application.Abstractions;

namespace tm.Application.Commands;

public record ReserveParkingSpotForCleaning(DateTime Date) : ICommand;
