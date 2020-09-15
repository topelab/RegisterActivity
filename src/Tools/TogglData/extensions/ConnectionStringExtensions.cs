using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

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
