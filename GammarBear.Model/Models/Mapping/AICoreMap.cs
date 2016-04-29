using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GammarBear.Model.Models.Mapping
{
    public class AICoreMap : EntityTypeConfiguration<AICore>
    {
        public AICoreMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.AIInfomation)
                .HasMaxLength(1000);

            this.Property(t => t.AIRespone)
                .HasMaxLength(2000);

            this.Property(t => t.AIInfoType)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("AICore");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AIInfomation).HasColumnName("AIInfomation");
            this.Property(t => t.AIRespone).HasColumnName("AIRespone");
            this.Property(t => t.AIInfoType).HasColumnName("AIInfoType");
        }
    }
}
