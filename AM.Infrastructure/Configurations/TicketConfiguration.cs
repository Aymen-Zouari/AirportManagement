using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(f => new { f.PassengerFk, f.FlightFk, f.NumTicket });//clé primaire compose

            // Configurer la cle etrangere
            builder.HasOne<Passenger>(f => f.Passenger)
                .WithMany(p => p.Tickets)
                .HasForeignKey(f => f.PassengerFk);

            // Configurer la cle etrangere
            builder.HasOne<Flight>(f => f.Flight)
           .WithMany(p => p.Tickets)
           .HasForeignKey(f => f.FlightFk);
        }
    }
}
