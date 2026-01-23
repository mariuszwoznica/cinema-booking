using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CinemaBooking.Common.Infrastructure.EFCore;

public static class ValueConversionExtensions
{
    /// <summary>
    /// Configures a collection of enum values to be stored as a <c>jsonb</c> column.
    /// </summary>
    /// <typeparam name="TEnum">The enum type in the collection</typeparam>
    /// <param name="builder">The property builder</param>
    /// <returns>The <see cref="PropertyBuilder{TProperty}"/> for further configuration.</returns>
    public static PropertyBuilder<ICollection<TEnum>> HasJsonbEnumCollectionConversion<TEnum>(
        this PropertyBuilder<ICollection<TEnum>> builder) where TEnum : Enum
    {
        var converter = new ValueConverter<ICollection<TEnum>, string>
        (
            v => v != null ? JsonSerializer.Serialize(v.Select(e => e.ToString()).ToList()) : null,
            v => string.IsNullOrEmpty(v)
                ? null
                : JsonSerializer.Deserialize<ICollection<string>>(v)
                    .Select(e => (TEnum)Enum.Parse(typeof(TEnum), e)).ToList()
        );

        var comparer = new ValueComparer<ICollection<TEnum>>
        (
            (l, r) => l.SequenceEqual(r),
            v => v.Aggregate(0, (a, e) => HashCode.Combine(a, e.GetHashCode())),
            v => v.ToList()
        );

        builder.HasColumnType("jsonb");
        builder.HasConversion(converter);
        builder.Metadata.SetValueComparer(comparer);

        return builder;
    }
}