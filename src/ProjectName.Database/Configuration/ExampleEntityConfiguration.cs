using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectName.Database.Abstractions.Entities;

namespace ProjectName.Database.Configuration
{
    public class ExampleEntityConfiguration : IEntityTypeConfiguration<ExampleEntity>
    {
        public void Configure(EntityTypeBuilder<ExampleEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.ExampleValue1).IsUnique();
        }
    }
}
