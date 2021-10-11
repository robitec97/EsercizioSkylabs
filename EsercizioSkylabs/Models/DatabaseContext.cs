using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsercizioSkylabs.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<RecordsDenormalized> RecordsDenormalized { get; set; }
        public DbSet<Records> Records { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
                .Entity<RecordsDenormalized>()
                .ToView("records_denormalized")
                .HasKey(t => t.id);
            builder
                .Entity<Records>()
                .ToTable("records")
                .HasKey(t => t.id);
        }
    }
}
