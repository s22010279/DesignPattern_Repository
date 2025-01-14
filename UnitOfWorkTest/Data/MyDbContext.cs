using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UnitOfWorkTest.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<ActiveUser> ActiveUsers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Order
            modelBuilder.Entity<Order>(e =>
            {
                e.HasKey(e => e.OrderId).IsClustered(true);
                e.Property(e => e.OrderId).HasColumnType("int").UseIdentityColumn(1, 1).IsRequired();
                e.Property(e => e.OrderDate).HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();
                e.Property(e => e.OrderTotal).HasColumnType("money").IsRequired();
            });
            #endregion

            #region User
            modelBuilder.Entity<User>(e =>
           {
               e.HasKey(e => e.Id).IsClustered(true);
               e.HasIndex(e => new { e.Id, e.Name }).IsUnique();
               e.Property(e => e.Name).IsRequired();
           });
            #endregion

            #region ActiveUser
            modelBuilder.Entity<ActiveUser>(e =>
            {
                e.Property(e => e.Id).HasColumnType("int").IsRequired();
                e.Property(e => e.Id).HasColumnType("int").IsRequired();
                e.Property(e => e.Active).HasColumnType("bit").IsRequired().HasDefaultValue(0);

                e.Property(e => e.AutoId).UseIdentityColumn(1, 1).IsRequired();
                e.HasKey(e => e.AutoId).IsClustered(true);
                e.HasIndex(e => e.Id).IsUnique();

                e.HasOne(e => e.User)
                .WithMany(e => e.ActiveUsers)
                .HasForeignKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion
        }

    }
}