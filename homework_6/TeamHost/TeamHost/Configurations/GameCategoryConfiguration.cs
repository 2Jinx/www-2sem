using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Entities;

namespace TeamHost.Configurations;

public class GameCategoryConfiguration: IEntityTypeConfiguration<GameCategory>
{
    public void Configure(EntityTypeBuilder<GameCategory> builder)
    {
        builder.HasKey(gc => new { gc.GameId, gc.CategoryId });
    }
}