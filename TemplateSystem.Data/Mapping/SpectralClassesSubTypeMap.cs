using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TemplateSystem.Entity.Models;

namespace TemplateSystem.Data.Mapping
{
    public class SpectralClassesSubTypeMap : EntityTypeConfiguration<SpectralClassesSubType>
    {
        public SpectralClassesSubTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("SpectralClassesSubType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Scale).HasColumnName("Scale");
        }
    }
}
