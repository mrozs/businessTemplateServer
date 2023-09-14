﻿using tm.Core.Exceptions;

namespace tm.Core.ValueObjects;

public sealed record ReservationId
{
    public Guid Value { get; }

    public ReservationId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static ReservationId Create() => new(Guid.NewGuid());
    public static implicit operator Guid(ReservationId name) => name.Value;
    public static implicit operator ReservationId(Guid value) => new (value);
}
