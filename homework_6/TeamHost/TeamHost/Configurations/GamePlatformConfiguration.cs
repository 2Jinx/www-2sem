using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Entities;

namespace TeamHost.Configurations;

public class GamePlatformConfiguration: IEntityTypeConfiguration<GamePlatform>
{
    public void Configure(EntityTypeBuilder<GamePlatform> builder)
    {
        builder.HasKey(gc => new { gc.GameId, gc.PlatformId });
    }
}