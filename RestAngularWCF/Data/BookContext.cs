using RestAngularWCF.Domain.Entity;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RestAngularWCF.Data
{
    public class BookContext : DbContext
    {
        public BookContext() : base("BookContext") { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // TODO Erasmus
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        }
    }
}