using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TarakannovWb.Controllers;
using TarakannovWb.Models;

namespace TarakanovWb
{
    public class TarakanovWbContext : DbContext
    {
        public TarakanovWbContext() : base("TarakanovWbContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Dishes> Dishes { get; set; }
        public DbSet<Eaten> Eatens { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}