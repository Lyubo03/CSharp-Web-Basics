namespace Suls.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class RepositoryConfiguration : IEntityTypeConfiguration<Repository>
    {
        public void Configure(EntityTypeBuilder<Repository> repo)
        {
            repo
                .HasMany(c => c.Commits)
                .WithOne(r => r.Repository);
        }
    }
}