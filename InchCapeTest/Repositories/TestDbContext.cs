using Microsoft.EntityFrameworkCore;
using InchCapeTest.Entities;

namespace InchCapeTest.Repositories
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
           : base(options)
        {

        }
        public DbSet<MakeEntity> MakeEntities { get; set; }
        public DbSet<VehicleTypeEntity> VehicleTypeEntities { get; set; }
        public DbSet<QuoteTypeEntity> QuoteTypeEntities { get; set; }
        public DbSet<AprRangeEntity> AprRangeEntities { get; set; }
        public DbSet<VehicleEntity> VehicleEntities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleTypeEntity>()
                .Property(c => c.Id)
                .IsRequired();
            modelBuilder.Entity<QuoteTypeEntity>()
                .Property(r => r.Id)
                .IsRequired();
            modelBuilder.Entity<AprRangeEntity>()
                .Property(r => r.Id)
                .IsRequired();
            modelBuilder.Entity<VehicleEntity>()
                .HasOne<VehicleTypeEntity>();
            modelBuilder.Entity<VehicleEntity>()
                .HasOne<QuoteTypeEntity>();
            modelBuilder.Entity<VehicleEntity>()
                .HasOne<MakeEntity>();
            modelBuilder.Entity<VehicleEntity>()
                .HasOne<AprRangeEntity>(v => v.AprRange);

            modelBuilder.Entity<MakeEntity>()
                .HasData(
                    new MakeEntity
                    {
                        Id = 1,
                        Make = "Audi"
                    },
                    new MakeEntity
                    {
                        Id = 2,
                        Make = "BMW"
                    }
                );
            modelBuilder.Entity<VehicleTypeEntity>()
                .HasData(
                    new VehicleTypeEntity
                    {
                        Id = 1,
                        VehicleType = "Bike"
                    },
                    new VehicleTypeEntity
                    {
                        Id = 2,
                        VehicleType = "Car"
                    },
                    new VehicleTypeEntity
                    {
                        Id = 3,
                        VehicleType = "Van"
                    }
                );
            modelBuilder.Entity<QuoteTypeEntity>()
                .HasData(
                    new QuoteTypeEntity
                    {
                        Id = 1,
                        QuoteType = "HP"
                    },
                    new QuoteTypeEntity
                    {
                        Id = 2,
                        QuoteType = "PCP"
                    }
                );
            modelBuilder.Entity<AprRangeEntity>().HasData(
                new AprRangeEntity(1, 5.0, 6.0, 7.0, 8.0),
                new AprRangeEntity(2, 6.0, 7.0, 8.0, 9.0),
                new AprRangeEntity(3, 4.0, 4.0, 4.0, 4.0),
                new AprRangeEntity(4, 5.0, 6.0, 7.0, 8.0)
            );
            modelBuilder.Entity<VehicleEntity>()
                .HasData(
                    new VehicleEntity
                    {
                        Id =  1,
                        MakeId = 1,
                        VehicleTypeId = 2,
                        QuoteTypeId = 2,
                        AprRangeId = 1
                    },
                    new VehicleEntity
                    {
                        Id =  2,
                        MakeId = 1,
                        VehicleTypeId = 2,
                        QuoteTypeId = 1,
                        AprRangeId = 2
                    },
                    new VehicleEntity
                    {
                        Id =  3,
                        MakeId = 1,
                        VehicleTypeId = 3,
                        QuoteTypeId = 2,
                        AprRangeId = 3
                    },
                    new VehicleEntity
                    {
                        Id =  4,
                        MakeId = 2,
                        VehicleTypeId = 1,
                        QuoteTypeId = 1,
                        AprRangeId = 4
                    }
                );
        }

    }
}
