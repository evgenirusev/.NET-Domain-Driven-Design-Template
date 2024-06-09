using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder
            .HasKey(m => m.Id);

        builder
            .Property<string>("serializedData")
            .IsRequired()
            .HasField("serializedData");

        builder
            .Property(m => m.Type)
            .IsRequired()
            .HasConversion(
                t => t.AssemblyQualifiedName,
                t => Type.GetType(t!)!);

        builder
            .Ignore(m => m.Data);
    }
}