using System.Data.Entity;
using TemplateSystem.Data.Mapping;
using TemplateSystem.Entity.Models;

namespace TemplateSystem.Data.Models
{
    public partial class StarSystemContext : DbContext
    {
        static StarSystemContext()
        {
            Database.SetInitializer<StarSystemContext>(null);
        }

        public StarSystemContext()
            : base("Name=StarSystemContext")
        {
            // the terrible hack
            var ensureDLLIsCopied =
                    System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<SpectralClassesSubType> SpectralClassesSubTypes { get; set; }
        public DbSet<StarDesc> StarDescs { get; set; }
        public DbSet<StarTypeByLuminosityClass> StarTypeByLuminosityClasses { get; set; }
        public DbSet<StarTypeBySpectralClass> StarTypeBySpectralClasses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SpectralClassesSubTypeMap());
            modelBuilder.Configurations.Add(new StarDescMap());
            modelBuilder.Configurations.Add(new StarTypeByLuminosityClassMap());
            modelBuilder.Configurations.Add(new StarTypeBySpectralClassMap());
        }
    }
}
