using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tm.Core.Entities;
using tm.Core.ValueObjects;

namespace tm.Infrastructure.DAL.Configurations
{
    internal sealed class VehicleReservationConfiguration : IEntityTypeConfiguration<VehicleReservation>
    {
        public void Configure(EntityTypeBuilder<VehicleReservation> builder)
        {
            builder.Property(x => x.EmployeeName)
                .HasConversion(x => x.Value, x => new EmployeeName(x));
            builder.Property(x => x.LicensePlate)
                .HasConversion(x => x.Value, x => new LicensePlate(x));

        }
    }
}
