namespace CinemaBooking.Common.Infrastructure.Utilities;

public static class IEnumerableExtensions
{
    extension<T>(IEnumerable<T> source)
    {
        public string ToDelimitedString(Func<T, string> formatter, string separator = ",")
        {
            if (formatter is not null && source is not null)
            {
                return string.Join(separator, source.Select(formatter));
            }

            return string.Empty;
        }
    }
}