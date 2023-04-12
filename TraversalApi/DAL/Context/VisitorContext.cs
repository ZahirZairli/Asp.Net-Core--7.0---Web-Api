using Microsoft.EntityFrameworkCore;
using TraversalApi.DAL.Entities;

namespace TraversalApi.DAL.Context
{
    public class VisitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-SDVG61S\\SQLEXPRESS;database=TraversalApiDb;integrated security=true;TrustServerCertificate=True;");
        }
        public DbSet<Visitor> Visitors  { get; set; }
    }
}
