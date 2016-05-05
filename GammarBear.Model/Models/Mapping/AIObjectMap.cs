using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GammarBear.Model.Models.Mapping
{
    public class AIObjectMap : EntityTypeConfiguration<AIObject>
    {
        public AIObjectMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ObjectName)
                .HasMaxLength(100);

            this.Property(t => t.ObjectDec)
                .HasMaxLength(2000);

            this.Property(t => t.ForTable)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("AIObject");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ObjectName).HasColumnName("ObjectName");
            this.Property(t => t.ObjectDec).HasColumnName("ObjectDec");
            this.Property(t => t.ForTable).HasColumnName("ForTable");
        }
    }
}
