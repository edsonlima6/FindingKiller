using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FindKiller.Models.DB
{
    public class ContextDB : DbContext
    {
        public ContextDB() : base("MovieDBContext")
        {

        }

        public DbSet<Gun> Gun { get; set; }
        public DbSet<Local> Local { get; set; }
        public DbSet<Suspect> Suspect { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }




    }
}
