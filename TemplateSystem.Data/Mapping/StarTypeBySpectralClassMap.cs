using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TemplateSystem.Entity.Models;

namespace TemplateSystem.Data.Mapping
{
    public class StarTypeBySpectralClassMap : EntityTypeConfiguration<StarTypeBySpectralClass>
    {
        public StarTypeBySpectralClassMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StarTypeDesc)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("StarTypeBySpectralClass");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.StarTypeDesc).HasColumnName("StarTypeDesc");
        }
    }
}
