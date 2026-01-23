using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CinemaBooking.Common.Infrastructure.EFCore;

public static class ValueConversionExtensions
{
    public static PropertyBuilder<ICollection<TEnum>> EnumCollectionJsonConversion<TEnum>(
        PropertyBuilder<ICollection<TEnum>> builder) where TEnum : Enum
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
            v => (ICollection<TEnum>)v.ToList()
        );

        builder.HasConversion(converter);
        builder.Metadata.SetValueComparer(comparer);

        return builder;
    }
}