using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GammarBear.Model.Models.Mapping
{
    public class AIResultMap : EntityTypeConfiguration<AIResult>
    {
        public AIResultMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Request)
                .HasMaxLength(500);

            this.Property(t => t.Respsone)
                .HasMaxLength(500);

            this.Property(t => t.RequestClinetInfo)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("AIResult");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Request).HasColumnName("Request");
            this.Property(t => t.Respsone).HasColumnName("Respsone");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.RequestClinetInfo).HasColumnName("RequestClinetInfo");
            this.Property(t => t.IsReply).HasColumnName("IsReply");
        }
    }
}
