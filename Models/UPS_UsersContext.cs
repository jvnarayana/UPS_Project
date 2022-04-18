using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Interview.Models
{
    public partial class UPS_UsersContext : DbContext
    {
        public UPS_UsersContext()
        {
        }

        public UPS_UsersContext(DbContextOptions<UPS_UsersContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=USC-W-GDLRV93;Initial Catalog=UPS_Users;User Id=GROUPINFRA\venkata.jadda;password=Ammulu$878;");
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Transaction>(entity =>
        //    {
        //        entity.Property(e => e.AmountBilled).HasColumnType("decimal(18, 0)");

        //        entity.Property(e => e.UserId).HasColumnName("User_Id");

        //        entity.HasOne(d => d.User)
        //            .WithMany(p => p.Transaction)
        //            .HasForeignKey(d => d.UserId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_User_Transaction");
        //    });

        //    modelBuilder.Entity<User>(entity =>
        //    {
        //        entity.Property(e => e.FirstName)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);

        //        entity.Property(e => e.LastName)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
