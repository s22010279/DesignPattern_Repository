using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UnitOfWorkTest
{
    [Table("Users")]
    public class User
    {
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("Name", TypeName = "varchar(500)")]
        public string Name { get; set; } = string.Empty;

        //references
        public IEnumerable<ActiveUser> ActiveUsers { get; set; } = null!;
    }

    [Table("ActiveUser")]
    public class ActiveUser
    {
        public int AutoId { get; set; }
        public int Id { get; set; }
        public bool Active { get; set; } = false;

        //references
        public User User { get; set; } = null!;
    }


    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<ActiveUser> ActiveUsers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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