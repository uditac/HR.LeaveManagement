﻿using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using HR.LeaveManagement.Persistence.DatabaseContext.Configurations;
using Microsoft.EntityFrameworkCore;


namespace HR.LeaveManagement.Persistence.DatabaseContext
{
    public class HRDatabaseContext : DbContext
    {
        public HRDatabaseContext(DbContextOptions<HRDatabaseContext> options) : base(options) 
        { 
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRDatabaseContext).Assembly);

            modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());


            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State ==  EntityState.Modified).ToList()) 
            {
                entry.Entity.DateModified = DateTime.UtcNow;
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
