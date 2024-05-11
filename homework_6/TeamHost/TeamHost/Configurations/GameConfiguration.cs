using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Entities;

namespace TeamHost.Configurations;

public class GameConfiguration: IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.Property(x => x.ReleaseDate)
            .HasColumnType("date");
    }
}