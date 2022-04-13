using System.Linq;

namespace System
{
    public static class ConnectionStringExtensions
    {
        public static string GetPart(this string connString, string part)
        {
            var parts = connString.Split(';', StringSplitOptions.RemoveEmptyEntries);
            var result = parts.FirstOrDefault(p => p.StartsWith($"{part}="));
            return result == null ? null : result.Split('=')[1].Trim();
        }
    }
}
