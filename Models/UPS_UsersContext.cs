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

        public List<User> Users { get; set; }
        public List<Transaction> Transactions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=USC-W-GDLRV93;Initial Catalog=UPS_Users;User Id=GROUPINFRA\venkata.jadda;password=Ammulu$878;Trusted_Connection = true");
            }
        }

    }
}
