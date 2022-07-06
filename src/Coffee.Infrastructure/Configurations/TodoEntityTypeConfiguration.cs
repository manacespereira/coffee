using Coffee.Domain.AggregatesModel.TodoAggregates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coffee.Infrastructure.Configurations;

public class TodoEntityTypeConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("todos", TodoContext.DEFAULT_SCHEMA);

        builder.HasKey(o => o.Id);

        builder.Ignore(b => b.DomainEvents);

        builder.Property(o => o.Id)
            .HasColumnName("id")
            .UseHiLo("todoseq", TodoContext.DEFAULT_SCHEMA);

        builder
            .Property(x => x.Title)
            .HasColumnName("title")
            .IsRequired();

        builder
            .Property(x => x.Description)
            .HasColumnName("description")
            .IsRequired(false);

        builder
            .Property(x => x.IsCompleted)
            .HasColumnName("is_completed")
            .IsRequired();
    }
}