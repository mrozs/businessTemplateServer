namespace tm.Core.Exceptions;

public sealed class InvalidLicensePlateException : CustomException
{
    public string LicensePlate { get; set; }

    public InvalidLicensePlateException(string licensePlate) : base($"License plate {licensePlate} is invalid")
    {
        LicensePlate = licensePlate;
    }
}
