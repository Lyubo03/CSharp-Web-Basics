namespace Suls.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user
                .HasMany(c => c.Commits)
                .WithOne(c => c.Creator)
                .OnDelete(DeleteBehavior.Restrict);

            user
                .HasMany(r => r.Respositories)
                .WithOne(o => o.Owner);
        }
    }
}