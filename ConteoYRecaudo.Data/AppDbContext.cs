using ConteoYRecaudo.Model.Models;
using System.Data.Entity;

namespace ConteoYRecaudo.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext() : base("name=ConnectionDb") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }

        public DbSet<Recaudos> Recaudos { get; set; }
    }
}
