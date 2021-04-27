using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TemplateSystem.Entity.Models;

namespace TemplateSystem.Data.Mapping
{
    public class StarTypeByLuminosityClassMap : EntityTypeConfiguration<StarTypeByLuminosityClass>
    {
        public StarTypeByLuminosityClassMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TypeDesc)
                .HasMaxLength(50);

            this.Property(t => t.CommonNameType)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("StarTypeByLuminosityClass");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TypeDesc).HasColumnName("TypeDesc");
            this.Property(t => t.CommonNameType).HasColumnName("CommonNameType");
        }
    }
}
