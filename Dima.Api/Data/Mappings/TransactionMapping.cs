using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
                .IsRequired(true)
                .HasColumnType("TEXT")
                .HasMaxLength(100);

        builder.Property(x => x.CreatedAt)
                .IsRequired(true);

        builder.Property(x => x.PaidOrReceivedAt)
                .IsRequired(false);

        builder.Property(x => x.Type)
                .IsRequired(true)
                .HasColumnType("INTEGER");

        builder.Property(x => x.Amount)
                .IsRequired(true)
                .HasColumnType("REAL");

        builder.Property(x => x.UserId)
                .IsRequired(true)
                .HasColumnType("TEXT")
                .HasMaxLength(160);
    }
}