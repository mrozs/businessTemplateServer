using tm.Core.ValueObjects;

namespace tm.Core.Exceptions;

public sealed class NoReservationPolicyFoundException : CustomException
{
    public JobTitle JobTitle { get; }

    public NoReservationPolicyFoundException(JobTitle jobTitle) : base($"No reservation policy {jobTitle} has been found")
    {
        JobTitle = jobTitle;    
    }
}