using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GammarBear.Model.Models.Mapping
{
    public class AISessionMap : EntityTypeConfiguration<AISession>
    {
        public AISessionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.SessionID)
                .HasMaxLength(100);

            this.Property(t => t.RequestText)
                .HasMaxLength(2000);

            this.Property(t => t.ResponseText)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("AISession");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SessionID).HasColumnName("SessionID");
            this.Property(t => t.RequestText).HasColumnName("RequestText");
            this.Property(t => t.ResponseText).HasColumnName("ResponseText");
            this.Property(t => t.State).HasColumnName("State");
        }
    }
}
