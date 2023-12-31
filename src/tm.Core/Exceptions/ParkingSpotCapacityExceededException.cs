﻿using tm.Core.ValueObjects;

namespace tm.Core.Exceptions;

public sealed class ParkingSpotCapacityExceededException : CustomException
{
    public ParkingSpotId ParkingSpotId { get; }

    public ParkingSpotCapacityExceededException(ParkingSpotId parkingSpotId) 
        : base($"Parking spot with id: {parkingSpotId} exceeds its reservation capacity")
    {
        ParkingSpotId = parkingSpotId;
    }
}