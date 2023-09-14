namespace tm.Core.Exceptions;

public sealed class InvalidReservationDateException : CustomException
{
    public DateTime Date { get; }

    public InvalidReservationDateException(DateTime date) : base($"Invalid reservation date {date:d}")
    {
        Date = date;
    }
}