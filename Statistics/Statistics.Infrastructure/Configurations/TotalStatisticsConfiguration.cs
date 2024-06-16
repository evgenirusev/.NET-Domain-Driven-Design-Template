using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class TotalStatisticsConfiguration : IEntityTypeConfiguration<TotalStatistics>
{
    public void Configure(EntityTypeBuilder<TotalStatistics> builder)
    {
        builder
            .HasKey(s => s.Id);
            
        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd();
    }
}
