using System.Data.Entity;
using TemplateSystem.Data.Mapping;
using TemplateSystem.Entity.Models;

namespace TemplateSystem.Data.Models
{
    public partial class TemplateSystemDBContext : DbContext
    {
        static TemplateSystemDBContext()
        {
            Database.SetInitializer<TemplateSystemDBContext>(null);
        }

        public TemplateSystemDBContext() : base("Name=TemplateSystemDBContext")
        {
            // the terrible hack
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentMap());
        }
    }
}