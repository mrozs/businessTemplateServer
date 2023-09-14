namespace tm.Core.Exceptions;

public sealed class InvalidCapacityException : CustomException
{
    public int Capacity { get; }

    public InvalidCapacityException(int capacity) 
        : base($"Invalid capcity: {capacity} ")
        => Capacity = capacity;
}