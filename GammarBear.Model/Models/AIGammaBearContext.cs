using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using GammarBear.Model.Models.Mapping;

namespace GammarBear.Model.Models
{
    public partial class AIGammaBearContext : DbContext
    {
        static AIGammaBearContext()
        {
            Database.SetInitializer<AIGammaBearContext>(null);
        }

        public AIGammaBearContext()
            : base("Name=AIGammaBearContext")
        {
        }

        public DbSet<AICore> AICores { get; set; }
        public DbSet<AIResult> AIResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AICoreMap());
            modelBuilder.Configurations.Add(new AIResultMap());
        }
    }
}
